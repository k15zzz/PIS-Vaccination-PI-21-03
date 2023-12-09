using System.IdentityModel.Tokens.Jwt;
using System.Text;
using PIS_Vaccination_PI_21_03.Source.Models.EntitiesModels;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Middleware;

//TODO: пишущий логер
public class LogWriterMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var request = context.Request;
        
        var authToken = request
            .Headers["Authorization"]
            .ToString();

        if (string.IsNullOrEmpty(authToken))
        {
            Console.Error.WriteLine("authToken is null, if its authorization its normal, if its not - bad");
            await next(context);
            return;
        }
        
        string objectDescription = "";
        string documentId = "";
        try
        {
            (objectDescription,  documentId) = new SubLogger(context).SetDescription().Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await next(context);
            return;
        }
        
        var userId = new JwtSecurityTokenHandler()
            .ReadJwtToken(authToken)
            .Payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"]
            .ToString();

        await using(var db = new AppDbContext())
        {
            var user = db.Users.Find(int.Parse(userId));
            if (user == null)
            {
                await next(context);
                return;
            }
            
            db.Loggings.Add(new LogEntitiesModel()
            {
                Surname = user.Surname,
                Name = user.Name,
                Patronymic = user.Patronymic,
                Phone = user.Phone,
                Email = user.Email,
                Organization = (await db.Organizations.FindAsync(user.FkOrg)).FullName,
                Position = (await db.Roles.FindAsync(user.FkRole)).Name,
                WorkPhone = user.WorkPhone,
                WorkEmail = user.WorkEmail,
                Login = user.Login,
                LogDate = DateTime.Now.ToUniversalTime(),
                ObjId = documentId,
                ObjDescr = objectDescription
            });
            await db.SaveChangesAsync();
        }
        await next(context);
    }
}

public class SubLogger
{ private Dictionary<string, Func<string, Task<Tuple<string, string>>>> Seters { get; }
    private string Action { get; }
    private readonly string _ojectId;
    private readonly HttpContext _context;
    
    
    public SubLogger(HttpContext context)
    {
        _context = context;
        
        var routes = _context
            .Request
            .Path
            .ToString()
            .Split('/');
        
        Action = routes[4];
        _ojectId = routes[3];

        Seters = new Dictionary<string, Func<string, Task<Tuple<string, string>>>>()
        {
            { "create", CreateUpdateAction },
            {"read", DeleteReadAction},
            {"list", ListAction},
            {"update", CreateUpdateAction},
            {"delete", DeleteReadAction}
        };
    }

    public async Task<Tuple<string, string>> SetDescription()
    {
        try
        {
           return await Seters[Action].Invoke(Action);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private Task<Tuple<string, string>> ListAction(string descriptionpreset)
        =>
            Task.FromResult<Tuple<string, string>>(new(descriptionpreset + " the list", _ojectId ));
    
    private Task<Tuple<string, string>> DeleteReadAction(string descriptionpreset)
        => Task.FromResult<Tuple<string, string>>(new(descriptionpreset + " the object", _ojectId + "." + _context.Request.QueryString.ToString().Substring(4)));

    private async Task<Tuple<string, string>> CreateUpdateAction(string descriptionpreset)
    {
        string requestBody;
        _context.Request.EnableBuffering();
        using (StreamReader reader = new StreamReader(_context.Request.Body, Encoding.UTF8, true, 1024, true))
        {
            requestBody = await reader.ReadToEndAsync();
            _context.Request.Body.Position = 0;
        }
        
        return new(descriptionpreset +  " the object:\n" + requestBody  , _ojectId);
    }
}
