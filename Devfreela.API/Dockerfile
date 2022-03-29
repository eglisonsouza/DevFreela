#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Devfreela.API/Devfreela.API.csproj", "Devfreela.API/"]
RUN dotnet restore "Devfreela.API/Devfreela.API.csproj"
COPY . .
WORKDIR "/src/Devfreela.API"
RUN dotnet build "Devfreela.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Devfreela.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devfreela.API.dll"]