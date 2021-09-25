#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mafmax.AssetsProvider.Main/Mafmax.AssetsProvider.Main.csproj", "Mafmax.AssetsProvider.Main/"]
RUN dotnet restore "Mafmax.AssetsProvider.Main/Mafmax.AssetsProvider.Main.csproj"
COPY . .
WORKDIR "/src/Mafmax.AssetsProvider.Main"
RUN dotnet build "Mafmax.AssetsProvider.Main.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mafmax.AssetsProvider.Main.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mafmax.AssetsProvider.Main.dll"]