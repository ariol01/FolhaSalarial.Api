#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#copia csproje e restaura camadas
COPY *csproj ./
RUN dotnet restore

#copia e builda
COPY . ./
RUN dotnet publish -c Release -o out

#builda imagem do runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

#usa porta dinamica do heroku
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Folha.dll

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["FolhaSalarial.Api/Folha.csproj", "Folha/"]
#RUN dotnet restore "Folha/Folha/Folha.csproj"
#COPY . .
#WORKDIR "/src/Folha"
#RUN dotnet build "Folha.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Folha.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Folha.dll"]