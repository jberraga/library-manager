# 📚 Library Management System API

A modern RESTful API built with .NET 9 for managing a library system, including books, authors, categories, users, and borrowing operations.

## 🚀 Features

- **Complete CRUD Operations** for all entities
- **Entity Framework Core** with SQL Server integration
- **ASP.NET Core Identity** for user authentication
- **Custom Validation Attributes**
  - Age validation (12-150 years)
  - Temporary email blocking
- **OpenAPI/Swagger** documentation support
- **Service Layer Architecture** for clean separation of concerns

## 📋 Table of Contents

- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Database Schema](#database-schema)
- [Custom Validators](#custom-validators)
- [Configuration](#configuration)

## 🛠 Technologies

- **.NET 9.0**
- **ASP.NET Core Web API**
- **Entity Framework Core 9.0.9**
- **SQL Server**
- **ASP.NET Core Identity**
- **OpenAPI/Swagger**

### NuGet Packages

- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (9.0.9)
- `Microsoft.AspNetCore.Identity.UI` (9.0.9)
- `Microsoft.AspNetCore.OpenApi` (9.0.9)
- `Microsoft.EntityFrameworkCore` (9.0.9)
- `Microsoft.EntityFrameworkCore.SqlServer` (9.0.9)
- `Microsoft.EntityFrameworkCore.Tools` (9.0.9)
- `Microsoft.VisualStudio.Web.CodeGeneration.Design` (9.0.0)

## ✅ Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (local or Azure)
- An IDE (Visual Studio, Rider, or VS Code)

## 🏃 Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd WebApplication1
```

### 2. Update Connection String

Edit `appsettings.json` and update the connection string to point to your SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=library;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
  }
}
```

### 3. Apply Database Migrations

```bash
cd WebApplication1
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

The API will be available at:
- **HTTPS**: `https://localhost:5001`
- **HTTP**: `http://localhost:5000`

### 5. Access API Documentation

In development mode, navigate to:
```
https://localhost:5001/openapi/v1.json
```

## 🔌 API Endpoints

### Authors
- `GET /api/authors` - Get all authors
- `GET /api/authors/{id}` - Get author by ID
- `POST /api/authors` - Create new author
- `PATCH /api/authors/{id}` - Update author
- `DELETE /api/authors/{id}` - Delete author

### Books
- `GET /api/books` - Get all books
- `GET /api/books/{id}` - Get book by ID
- `POST /api/books` - Create new book
- `PATCH /api/books/{id}` - Update book
- `DELETE /api/books/{id}` - Delete book

### Categories
- `GET /api/categories` - Get all categories
- `GET /api/categories/{id}` - Get category by ID
- `POST /api/categories` - Create new category
- `PATCH /api/categories/{id}` - Update category
- `DELETE /api/categories/{id}` - Delete category

### Users
- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create new user
- `PATCH /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user

### Borrows
- `GET /api/borrows` - Get all borrow records
- `GET /api/borrows/{id}` - Get borrow by ID
- `POST /api/borrows` - Create new borrow record
- `PATCH /api/borrows/{id}` - Update borrow record
- `DELETE /api/borrows/{id}` - Delete borrow record

## 🗄 Database Schema

### Author
- `Id` (int, PK, Identity)
- `Firstname` (string, max 50)
- `Lastname` (string, max 50)
- `Country` (string, max 50)
- `Birthdate` (DateTime)

### Book
- `Id` (int, PK, Identity)
- `Name` (string, required, max 32)
- `Pages` (int)
- `AuthorId` (int, FK to Author)
- `CategoryId` (int, FK to Category)

### Category
- `Id` (int, PK, Identity)
- `Name` (string, required, max 32)
- `Description` (string, max 1024)
- `AgeRestriction` (int)

### User
- `Id` (int, PK, Identity)
- `Firstname` (string, required, max 32)
- `Lastname` (string, required, max 24)
- `Email` (string, max 64, validated)
- `Phone` (string, phone format)
- `Password` (string, required, max 128)
- `Languages` (List<string>)
- `Age` (int, validated 12-150)

### Borrow
- `Id` (int, PK, Identity)
- `Date` (DateTime)
- `Duration` (int, days)
- `BookId` (int, FK to Book)
- `UserId` (int, FK to User)

## 🔍 Custom Validators

### AgeAttribute
Validates that user age is between 12 and 150 years.

```csharp
[Age]
public int Age { get; set; }
```

### NoTempEmailAttribute
Blocks temporary/disposable email addresses from the following domains:
- tempmail.com
- 10minutemail.com
- mailinator.com
- guerrillamail.com
- throwawaymail.com
- mail.tm
- mail.gw

```csharp
[EmailAddress, NoTempEmail]
public string? Email { get; set; }
```

## ⚙️ Configuration

### Development Environment

The application uses different settings for development (defined in `appsettings.Development.json`).

### Identity Configuration

ASP.NET Core Identity is configured with:
- Email confirmation required for sign-in
- EntityFramework stores using `MyDbContext`

### Database Provider

SQL Server is used as the database provider. To change to a different provider:

1. Install the appropriate EF Core provider package
2. Update `Program.cs` to use the new provider
3. Update the connection string format

## 🔐 Security Notes

⚠️ **Important**: The connection string in `appsettings.json` contains sensitive credentials. 

**Before deploying to production:**
1. Remove hardcoded credentials from `appsettings.json`
2. Use Azure Key Vault, AWS Secrets Manager, or environment variables
3. Enable HTTPS and proper authentication/authorization
4. Implement rate limiting and API key validation
5. Add password hashing for User entity passwords

## 🧪 Testing

To run tests (when test project is added):

```bash
dotnet test
```

## 📝 License

This project is licensed under the MIT License.

## 👥 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📞 Support

For support and questions, please open an issue in the repository.

---

**Built with ❤️ using .NET 9**

