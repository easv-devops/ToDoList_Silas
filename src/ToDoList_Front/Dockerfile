﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG TAG
ENV ENVIRONMENT=$TAG
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG TAG
ENV ENVIRONMENT=$TAG
WORKDIR /src
COPY ["ToDoList_Front/ToDoList_Front.csproj", "ToDoList_Front/"]
RUN dotnet restore "ToDoList_Front/ToDoList_Front.csproj"
COPY . .
WORKDIR "/src/ToDoList_Front"
RUN dotnet build "ToDoList_Front.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
ARG TAG
ENV ENVIRONMENT=$TAG
RUN dotnet publish "ToDoList_Front.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ARG TAG
ENV ENVIRONMENT=$TAG
ENTRYPOINT ["dotnet", "ToDoList_Front.dll"]