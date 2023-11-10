FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore "PIS-Vaccination-PI-21-03/PIS-Vaccination-PI-21-03.csproj"

WORKDIR "/src/PIS-Vaccination-PI-21-03"

ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://dotnet:80"]
