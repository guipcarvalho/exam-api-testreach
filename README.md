# exam-api-testreach

This api was created for the TestReach test interview.

## Architectural Pattern
* Onion Architecture
## Technologies used
* .NET 5
* SQL Server
* Entity Framework Core
* MediatR (for CQRS)
* FluentValidation
* AutoMapper
* xUnit
* Moq
* FluentAssertions
* Docker
### How to run the project
Clone this repository and go to the root folder of the repository and type the following command in your terminal. PS: Docker needs to be installed.

```
docker-compose build
docker-compose up -d
```

After both API and Database containers are running on Docker, you can use the following URL to make requests to the application:

```
http://localhost:3000/swagger/
```

## Tests
For running the tests you should have the database container up in your docker, and you must have .NET 5 SDK installed to run the dotnet test command.
### Running unit tests
On the root of the repository, type the following command in your terminal
```
dotnet test .\tests\TestReach.Exam.UnitTests\
```

### Running integration tests
On the root of the repository, type the following command in your terminal
```
dotnet test .\tests\TestReach.Exam.IntegrationTests\
```