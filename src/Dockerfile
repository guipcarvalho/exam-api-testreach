FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestReach.Exam.API/TestReach.Exam.API.csproj", "TestReach.Exam.API/"]
RUN dotnet restore "TestReach.Exam.API/TestReach.Exam.API.csproj"
COPY . .
WORKDIR "/src/TestReach.Exam.API"
RUN dotnet build "TestReach.Exam.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestReach.Exam.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestReach.Exam.API.dll"]