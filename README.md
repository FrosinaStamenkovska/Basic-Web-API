**Basic-Web-API**

**Overview**
This is a ASP.NET Web Api application designed to manage data related to companies, countries, and contacts. It employs an N-tier architecture, uses Entity Framework for ORM, and incorporates Serilog for logging. The application connects to an MS SQL database and includes a suite of unit tests to ensure code quality and reliability.

**Features**
* Company Management: Create, Update, Delete, and Retrieve company information.
* Country Management: Create, Update, Delete, and Retrieve country information.
* Contact Management: Create, Update, Delete, and Retrieve contact information.
* Entity Framework Core: The application uses Entity Framework Core as the ORM to interact with the underlying database.
* Repository Pattern: The application follows the repository pattern to separate data access logic from business logic.
* Logging: Logs are created and stored in a designated folder - Logs.
* Validation: Model validation using FluentValidation.
* Unit Tests: Comprehensive unit tests using MSTest.

**Getting Started**
**Prerequisites**
* .NET 8.0
* MS SQL Server
* Visual Studio 2022 or later (optional but recommended for development)

**Installation**
1. Clone the Repository : https://github.com/FrosinaStamenkovska/Basic-Web-API.git
2. Set Up Database Connection: Update the ConnectionStrings section in appsettings.json to match your Database configuration
3. Update Database
4. Run the Application
5. Run the Unit Tests

**Technologies Used**
* .NET 8: Core framework.
* Entity Framework Core: ORM for database operations.
* FluentValidation: For model validation.
* Serilog: Logging library.
* MS SQL Server: Database server.
* MSTest: Testing framework.
