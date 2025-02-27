# Orchestrator API

A RESTful API developed in .NET for managing and orchestrating business tasks and processes.

## Features

- **Task Management**: Full CRUD operations to create, read, update, and delete tasks.
- **Authentication & Authorization**: Secure authentication using JWT tokens.
- **Scalability**: Designed to handle multiple concurrent processes.
- **Database Integration**: Supports both SQL and NoSQL databases.

## Technologies Used

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Swagger](https://swagger.io/) for interactive API documentation
- [JWT (JSON Web Tokens)](https://jwt.io/) for secure authentication

## Installation

Follow these steps to set up and run the project locally:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/cabu0124/orchestrator-api.git
   cd orchestrator-api
2. **Restore dependencies**:
   ```bash
   dotnet restore
3. **Update configuration**:<br>
   Provide the correct database connection strings in **appsettings.json**.
   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
       }
     },
     "AllowedHosts": "*",
     "DBConnection": "YOUR_DB_CONNECTION",
     "DatabaseName": "YOUR_DB_NAME"
   }
4. **Run the application**:<br>
   The API will be available at https://localhost:5001 or http://localhost:5000.
   ```bash
   dotnet run

## Usage

Once the application is running, you can explore the available endpoints using Swagger:
- Open your browser and go to https://localhost:5001/swagger.

## Contribution
Contributions are welcome! If you’d like to contribute:

- Fork the repository.
- Create a new branch (git checkout -b feature/new-feature).
- Make your changes and commit them (git commit -m 'Add new feature').
- Submit a pull request.
