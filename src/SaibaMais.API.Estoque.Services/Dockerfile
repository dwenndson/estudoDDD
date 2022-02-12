FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/SaibaMais.API.Estoque.Services/SaibaMais.API.Estoque.Services.csproj", "src/SaibaMais.API.Estoque.Services/"]
RUN dotnet restore "src/SaibaMais.API.Estoque.Services/SaibaMais.API.Estoque.Services.csproj"
COPY . .
WORKDIR "/src/src/SaibaMais.API.Estoque.Services"
RUN dotnet build "SaibaMais.API.Estoque.Services.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SaibaMais.API.Estoque.Services.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SaibaMais.API.Estoque.Services.dll"]