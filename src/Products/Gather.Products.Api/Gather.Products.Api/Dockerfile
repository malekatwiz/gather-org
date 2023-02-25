#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Products/Gather.Products.Api/Gather.Products.Api/Gather.Products.Api.csproj", "Products/Gather.Products.Api/Gather.Products.Api/"]
RUN dotnet restore "Products/Gather.Products.Api/Gather.Products.Api/Gather.Products.Api.csproj"
COPY . .
WORKDIR "/src/Products/Gather.Products.Api/Gather.Products.Api"
RUN dotnet build "Gather.Products.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gather.Products.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gather.Products.Api.dll"]