#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["SignalRHub/SignalRHub.csproj", "SignalRHub/"]
#RUN dotnet restore "SignalRHub/SignalRHub.csproj"
#COPY . .
#WORKDIR "/src/SignalRHub"
#RUN dotnet build "SignalRHub.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "SignalRHub.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "SignalRHub.dll"]

FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["SignalRHub/SignalRHub.csproj", "SignalRHub/"]
RUN dotnet restore "SignalRHub/SignalRHub.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "SignalRHub/SignalRHub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalRHub/SignalRHub.csproj" -c Release -o /app/publish \
   -r alpine-x64 \
   --self-contained true \
   -p:PublishTrimmed=true \
   -p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./SignalRHub"]


# docker build -t naam .
# docker run -it -p 8000:80 --rm -e ASPNETCORE_ENVIRONMENT=Development --name naam naam