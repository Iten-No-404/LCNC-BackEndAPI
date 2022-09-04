
# LCNC Design Tool Web API

This is the Web API for the Coded Summer Competition sponsered by ITWorx.
[Swagger API Documentation](https://abdullahadel-001-site1.etempurl.com/swagger/index.html)

## Code Structure

-  **Itworx-Backend** is the main layer that will run the program and hold controllers of the API's endpoints.
    - **Controller** folder which contains the APIs controllers.
    - **wwwroot** folder which contains all the static files and images we can use.
    - **program.cs** file is the startup file which connects with the database, connect services with **Itworx-Backend**, etc...
-  **Itworx-Backend.Domain** is the layer that contains all the database classes and models.
    - **Entities** folder is the main folder of this layer which contains the class models.
    - **Mapping** folder which contains the mapping between all classes.
-  **Itworx-Backend.Repository** is the layer that contains database context and migration files.
    - **ApplicationDbcontext.cs** is the file which we use when we add migrations.
    - **Repository** folder contains all the classes and methods that interact with the database.
    - **Migrations** folder contains all the migrations created.
-  **Itworx-Backend.Service** is the layer that hold all the business logic of the entities.

## Built Using

- C# language
- .NET Core 6
- ASP .NET Core Web API
- Entity Framework Core 6
- MS SQL Server

## Installation Guide

### Prerequisites:

- [Visual Studio IDE 2022](https://visualstudio.microsoft.com/downloads/) with .NET Core and Web Development workloads downloaded.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### 1. Clone the project:

```sh
cd https://github.com/itworx/CodedSummer2022_LCNC_T6_BackendAPI.git
```

### 2. Open Itworx-Backend folder

### 3. Open Itworx-Backend.sln file in Visual Studio

### 4. Set up the database connection string:

Open `appsettings.json` in `Itworx-Backend` folder and write your database connection string in `ConnectionStrings.myconn`.

### 5. Run the migrations to create the database tables:

- Go to **Tools --> NuGet Package Manager --> Package Manager Console**.
- Make sure that the `Default project` is **Itworx-Backend.Repository**. If not, please select it from the dropdown.
- Run the `update-database` command in the console.

### 6. Run the application:

Start the application by pressing `Ctrl + F5` and the application will start running at `http://localhost:5053/api`.
