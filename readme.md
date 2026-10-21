# Clean Architecture – ASP.NET Core MVC

A simple ASP.NET Core MVC application demonstrating **Clean Architecture**, using a traditional Service and Repository pattern.

## Overview

This project separates application responsibilities into independent layers to improve maintainability, testability, and separation of concerns.

The application manages courses, including course names, descriptions, and images, using ASP.NET Core MVC and Entity Framework Core.

## Architecture

The solution contains four projects:

```text
cleanArch
├── cleanArch.Domain
│   ├── Entities
│   │   └── Course.cs
│   └── Interfaces
│       └── ICourseRepository.cs
│
├── cleanArch.Application
│   ├── Interfaces
│   │   └── ICourseService.cs
│   ├── Services
│   │   └── CourseService.cs
│   └── ViewModels
│       └── CourseViewModel.cs
│
├── cleanArch.Infrastructure
│   ├── Data
│   │   └── ApplicationDbContext.cs
│   └── Repositories
│       └── CourseRepository.cs
│
└── cleanArch.Mvc
    ├── Controllers
    │   └── CoursesController.cs
    ├── Views
    │   └── Courses
    ├── wwwroot
    │   └── images
    └── Program.cs
```



## Technologies

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Dependency Injection
- Razor Views
- Bootstrap
- Repository Pattern
- Service Layer Pattern

## How It Works

The application follows this request flow:

```text
User
  ↓
MVC Controller
  ↓
Application Service
  ↓
Repository Interface
  ↓
Repository Implementation
  ↓
Entity Framework Core
  ↓
SQL Server
```

### Layer Responsibilities

**Domain**
- Contains entities and core business rules.
- Defines repository abstractions where appropriate.
- Does not depend on Infrastructure or MVC.

**Application**
- Contains application services and interfaces.
- Coordinates application operations.
- Defines ViewModels or DTOs used by the presentation layer, as appropriate.

**Infrastructure**
- Implements repository interfaces.
- Configures Entity Framework Core and database access.
- Contains database-related implementations.

**MVC**
- Handles HTTP requests and responses.
- Contains controllers, Razor views, and static files.
- Uses dependency injection to access application services.

## Course Features

- List all courses.
- View course details.
- Create courses.
- Edit course information.
- Delete courses.
- Display course images.

## Getting Started

### Prerequisites

- .NET SDK compatible with the project.
- Visual Studio or Visual Studio Code.
- SQL Server.
- Entity Framework Core tools.

### 1. Clone the Repository

```bash
git clone <YOUR-GITHUB-REPOSITORY-URL>
cd <YOUR-REPOSITORY-FOLDER>
```

### 2. Configure the Database

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=CleanArchUniversityDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Use your own SQL Server instance and appropriate credentials.

### 3. Apply Migrations

If migrations are already configured:

```bash
dotnet ef database update
```

If migrations are not configured, create them using the appropriate Infrastructure project and MVC startup project.

### 4. Run the Application

Set `cleanArch.Mvc` as the startup project in Visual Studio, or run:

```bash
dotnet run --project cleanArch.Mvc
```

Open the local URL shown in the terminal.

## Images

Course images can be stored in:

```text
cleanArch.Mvc/wwwroot/images/
```

For example:

```text
wwwroot/images/1.jpg
wwwroot/images/2.jpg
wwwroot/images/3.jpg
```

Use relative image paths such as `/images/1.jpg` in the database.


## Learning Objectives

This project demonstrates how to:

- Organize an ASP.NET Core solution using Clean Architecture.
- Apply dependency inversion and dependency injection.
- Separate business logic from database access.
- Use EF Core with SQL Server.
- Implement repository and service patterns.
- Build CRUD functionality with MVC controllers and Razor views.

## License

This project is intended for learning and educational purposes. Add a license file if you intend to distribute or reuse the project publicly.
