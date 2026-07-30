# NZwalks API

ASP.NET Core Web API built with .NET 8, Entity Framework Core, SQL Server, and Swagger.

This project was developed as part of a practical learning experience focused on building RESTful APIs from scratch using modern .NET technologies.

## Project Overview

NZwalks API is a Web API for managing regions and walks in New Zealand. The project demonstrates core backend development concepts such as:

- RESTful API design
- ASP.NET Core Web API with .NET 8
- Entity Framework Core with SQL Server
- CRUD operations
- DTOs and domain models
- Validation
- Swagger for API testing
- Asynchronous programming with async/await

## Technologies Used

- C#
- ASP.NET Core Web API
- .NET 8
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Visual Studio Code / .NET CLI

## Features

- Create, read, update and delete regions
- API endpoints documented with Swagger
- Database access through Entity Framework Core
- DTO-based request/response handling
- Clean controller-based API structure

## Project Structure

- `NZwalks.API/Controllers` – API controllers
- `NZwalks.API/Data` – EF Core DbContext and data access
- `NZwalks.API/models` – Domain models and DTOs
- `NZwalks.API/appsettings.json` – Application configuration

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio Code or Visual Studio

### Run the API

From the project root:

```bash
cd /Users/rc/NZwalks/NZwalks.API
dotnet run
```

Then open Swagger at:

```text
http://localhost:5162/swagger
```

## Notes

This project reflects strong backend development skills in:

- building scalable APIs
- working with relational databases
- applying EF Core and SQL Server
- creating clean and maintainable API architecture
- testing APIs with Swagger

## Summary for Recruiters

This project demonstrates practical experience with ASP.NET Core Web API development using .NET 8, Entity Framework Core, SQL Server, and RESTful architecture. It highlights the ability to build and test backend services following modern .NET best practices.
