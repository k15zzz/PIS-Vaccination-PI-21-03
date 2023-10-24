FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PIS-Vaccination-PI-21-03/PIS-Vaccination-PI-21-03.csproj", "PIS-Vaccination-PI-21-03/"]
RUN dotnet restore "PIS-Vaccination-PI-21-03/PIS-Vaccination-PI-21-03.csproj"
COPY . .
WORKDIR "/src/PIS-Vaccination-PI-21-03"
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://dotnet:80"]
#RUN dotnet build "PIS-Vaccination-PI-21-03.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "PIS-Vaccination-PI-21-03.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "PIS-Vaccination-PI-21-03.dll"]
