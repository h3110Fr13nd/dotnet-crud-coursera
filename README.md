# User Management API

A REST API built with ASP.NET Core 8.0 that provides user management functionality with CRUD operations, input validation, logging, and JWT authentication.

## Features

- CRUD operations for user management
- Input validation using Data Annotations
- Custom request logging middleware
- JWT Authentication
- Swagger documentation
- In-memory data storage

## Prerequisites

- .NET SDK 8.0 or later
- Git

## Getting Started

1. Clone the repository:
```bash
git clone <your-repository-url>
cd crud-coursera
```

2. Build and run the application:
```bash
cd UserManagementAPI
dotnet restore
dotnet run
```

The API will be available at:
- HTTP: http://localhost:5133
- Swagger UI: http://localhost:5133/swagger

## API Endpoints

### Users

- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get a specific user by ID
- `POST /api/users` - Create a new user
- `PUT /api/users/{id}` - Update an existing user
- `DELETE /api/users/{id}` - Delete a user

### Request/Response Examples

#### Create User
```json
POST /api/users
{
    "name": "John Doe",
    "email": "john.doe@example.com",
    "password": "Password123!"
}
```

#### Update User
```json
PUT /api/users/1
{
    "name": "John Doe Updated",
    "email": "john.updated@example.com",
    "password": "NewPassword123!"
}
```

## Project Structure

- `Controllers/` - API controllers
- `Models/` - Data models and DTOs
- `Repositories/` - Data access layer
- `Middleware/` - Custom middleware components

## Input Validation

The API implements the following validations:
- Name: Required, 2-50 characters
- Email: Required, valid email format
- Password: Required, minimum 6 characters

## Logging

The application includes a custom request logging middleware that logs:
- Incoming HTTP requests with method, path, and body
- Response status codes

## Authentication

JWT authentication is configured and can be enabled by setting the following in appsettings.json:
```json
{
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "your-issuer",
    "Audience": "your-audience"
  }
}
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

## License

This project is licensed under the MIT License.
