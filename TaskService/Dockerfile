#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TaskService/TaskService.csproj", "TaskService/"]
COPY ["TaskService.Entities/TaskService.Entities.csproj", "TaskService.Entities/"]
COPY ["TaskService.Repositories/TaskService.Repositories.csproj", "TaskService.Repositories/"]
COPY ["../RepositoryBase/RepositoryBase/RepositoryBase.csproj", "../RepositoryBase/RepositoryBase/"]
COPY ["../FindService/FindService.Client/FindService.Client.csproj", "../FindService/FindService.Client/"]
COPY ["../RepositoryBase/AuthenticationBase/AuthenticationBase.csproj", "../RepositoryBase/AuthenticationBase/"]
COPY ["TaskService.Services/TaskService.Services.csproj", "TaskService.Services/"]
RUN dotnet restore "TaskService/TaskService.csproj"
COPY . .
WORKDIR "/src/TaskService"
RUN dotnet build "TaskService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskService.dll"]