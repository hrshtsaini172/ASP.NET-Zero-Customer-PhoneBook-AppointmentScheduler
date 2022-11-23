#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MyTraining1121AngularDemo.Web.Host/MyTraining1121AngularDemo.Web.Host.csproj", "src/MyTraining1121AngularDemo.Web.Host/"]
COPY ["src/MyTraining1121AngularDemo.Web.Core/MyTraining1121AngularDemo.Web.Core.csproj", "src/MyTraining1121AngularDemo.Web.Core/"]
COPY ["src/MyTraining1121AngularDemo.Application/MyTraining1121AngularDemo.Application.csproj", "src/MyTraining1121AngularDemo.Application/"]
COPY ["src/MyTraining1121AngularDemo.Application.Shared/MyTraining1121AngularDemo.Application.Shared.csproj", "src/MyTraining1121AngularDemo.Application.Shared/"]
COPY ["src/MyTraining1121AngularDemo.Core.Shared/MyTraining1121AngularDemo.Core.Shared.csproj", "src/MyTraining1121AngularDemo.Core.Shared/"]
COPY ["src/MyTraining1121AngularDemo.Core/MyTraining1121AngularDemo.Core.csproj", "src/MyTraining1121AngularDemo.Core/"]
COPY ["src/MyTraining1121AngularDemo.EntityFrameworkCore/MyTraining1121AngularDemo.EntityFrameworkCore.csproj", "src/MyTraining1121AngularDemo.EntityFrameworkCore/"]
COPY ["src/MyTraining1121AngularDemo.GraphQL/MyTraining1121AngularDemo.GraphQL.csproj", "src/MyTraining1121AngularDemo.GraphQL/"]
RUN dotnet restore "src/MyTraining1121AngularDemo.Web.Host/MyTraining1121AngularDemo.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/MyTraining1121AngularDemo.Web.Host"
RUN dotnet build "MyTraining1121AngularDemo.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyTraining1121AngularDemo.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTraining1121AngularDemo.Web.Host.dll"]
