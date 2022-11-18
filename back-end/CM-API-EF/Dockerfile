FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["CM-API-EF/CM-API-EF.csproj", "CM-API-EF/"]
RUN dotnet restore "CM-API-EF/CM-API-EF.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "CM-API-EF/CM-API-EF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CM-API-EF/CM-API-EF.csproj" -c Release -o /app/publish \
   -r alpine-x64 \
   --self-contained true \
   -p:PublishTrimmed=true \
   -p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./CM-API-EF"]



# docker build -t naam .
# docker run -it -p 8000:80 --rm -e ASPNETCORE_ENVIRONMENT=Development --name naam naam


# naar swagger ui met: http://localhost:8000/swagger/index.html