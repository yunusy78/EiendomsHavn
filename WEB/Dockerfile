FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EiendomsHavn/EiendomsHavn.csproj", "EiendomsHavn/"]
RUN dotnet restore "EiendomsHavn/EiendomsHavn.csproj"
COPY . .
WORKDIR "/src/EiendomsHavn"
RUN dotnet build "EiendomsHavn.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EiendomsHavn.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EiendomsHavn.dll"]
