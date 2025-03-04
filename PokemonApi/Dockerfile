
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src

# Copiar el código fuente completo
COPY . .

# Restaurar dependencias
RUN dotnet restore "PokemonApi.csproj"

# Compilar el código
RUN dotnet build "PokemonApi.csproj" -c $configuration -o /app/build

# Publicar la aplicación
RUN dotnet publish "PokemonApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=true

# 🔹 Imagen final con SDK en lugar de solo runtime (IMPORTANTE)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app


COPY --from=build /app/publish .


COPY --from=build /src /app/source

# Asegurar que dotnet-ef está disponible
RUN dotnet tool install --global dotnet-ef
ENV PATH="/root/.dotnet/tools:${PATH}"


# Establecer el punto de entrada
ENTRYPOINT ["dotnet", "PokemonApi.dll"]
