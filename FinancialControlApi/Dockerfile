FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FinancialControl/FinancialControlApi/FinancialControlApi.csproj", "FinancialControlApi/"]
RUN dotnet restore "FinancialControlApi/FinancialControlApi.csproj"
COPY . .
WORKDIR "/src/FinancialControlApi"
RUN dotnet build "FinancialControlApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancialControlApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialControlApi.dll"]
