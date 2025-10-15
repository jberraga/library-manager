# Library Management System API

A modern RESTful API for managing a library system built with .NET 9, featuring JWT authentication, Entity Framework Core, and SQL Server.

## 🚀 Features

- **JWT Authentication**: Secure token-based authentication for API endpoints
- **User Management**: Register, login, and manage user accounts with BCrypt password hashing
- **Book Management**: CRUD operations for books with author and category relationships
- **Author Management**: Manage author information and their works
- **Category Management**: Organize books by categories
- **Borrow System**: Track book borrowing and returns
- **Custom Validation**: Email validation (no temporary emails), age validation, and phone number validation
- **Entity Framework Core**: Code-first approach with migrations
- **SQL Server**: Azure SQL Database integration

## 🛠️ Tech Stack

- **.NET 9.0**: Latest .NET framework
- **ASP.NET Core Web API**: RESTful API framework
- **Entity Framework Core 9.0.9**: ORM for database operations
- **SQL Server**: Database (Azure SQL)
- **JWT Bearer Authentication**: Secure token-based auth
- **BCrypt.Net**: Password hashing
- **OpenAPI/Swagger**: API documentation

## 📋 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (local or Azure)
- Your favorite IDE (Visual Studio, Rider, VS Code)

## 🔧 Installation

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd WebApplication1
   ```

2. **Update connection string**
   
   Edit `appsettings.json` with your SQL Server connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Your-Connection-String-Here"
     }
   }
   ```

3. **Update JWT Secret Key**
   
   For production, generate a secure secret key:
   ```json
   {
     "JwtSettings": {
       "SecretKey": "YourSecureSecretKeyHere-MinimumLength32Characters",
       "Issuer": "WebApplication1",
       "Audience": "WebApplication1",
       "ExpiryMinutes": "60"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5001` (or the port specified in `launchSettings.json`).

## 🔐 Authentication

### Register a New User

**POST** `/api/auth/register`

```json
{
  "firstname": "John",
  "lastname": "Doe",
  "email": "john.doe@example.com",
  "phone": "+1234567890",
  "password": "SecurePassword123",
  "languages": ["English", "Spanish"],
  "age": 25
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "user": {
    "id": 1,
    "firstname": "John",
    "lastname": "Doe",
    "email": "john.doe@example.com",
    "phone": "+1234567890",
    "languages": ["English", "Spanish"],
    "age": 25
  }
}
```

### Login

**POST** `/api/auth/login`

```json
{
  "email": "john.doe@example.com",
  "password": "SecurePassword123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "user": {
    "id": 1,
    "firstname": "John",
    "lastname": "Doe",
    "email": "john.doe@example.com",
    "phone": "+1234567890",
    "languages": ["English", "Spanish"],
    "age": 25
  }
}
```

### Using the JWT Token

Include the token in the `Authorization` header for all protected endpoints:

```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

## 📚 API Endpoints

All endpoints except `/api/auth/login` and `/api/auth/register` require JWT authentication.

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

### Borrows
- `GET /api/borrows` - Get all borrow records
- `GET /api/borrows/{id}` - Get borrow by ID
- `POST /api/borrows` - Create new borrow record
- `PATCH /api/borrows/{id}` - Update borrow record
- `DELETE /api/borrows/{id}` - Delete borrow record

### Users
- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create new user
- `PATCH /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user

## 🏗️ Project Structure

```
WebApplication1/
├── Attributes/           # Custom validation attributes
│   ├── AgeAttribute.cs
│   └── NoTempEmail.cs
├── Controllers/          # API controllers
│   ├── AuthController.cs
│   ├── AuthorsController.cs
│   ├── BooksController.cs
│   ├── BorrowsController.cs
│   ├── CategoriesController.cs
│   └── UsersController.cs
├── Data/                 # Database context and DTOs
│   ├── MyDbContext.cs
│   └── TransferObjects/
│       ├── AuthorDto.cs
│       ├── AuthResponseDto.cs
│       ├── BookDto.cs
│       ├── BorrowDto.cs
│       ├── CategoryDto.cs
│       ├── LoginDto.cs
│       ├── RegisterDto.cs
│       └── UserDto.cs
├── Entities/             # Database models
│   ├── Author.cs
│   ├── Book.cs
│   ├── Borrow.cs
│   ├── Category.cs
│   └── User.cs
├── Middlewares/          # Custom middleware
│   └── SessionMiddleware.cs
├── Migrations/           # EF Core migrations
├── Services/             # Business logic services
│   ├── AuthService.cs
│   ├── AuthorsService.cs
│   ├── BooksService.cs
│   ├── BorrowsService.cs
│   ├── CategoriesService.cs
│   └── UsersService.cs
├── Program.cs            # Application entry point
├── appsettings.json      # Configuration
└── WebApplication1.csproj
```

## 🔒 Security Features

- **Password Hashing**: BCrypt with salt for secure password storage
- **JWT Tokens**: Stateless authentication with configurable expiration
- **Token Validation**: Automatic validation via custom middleware
- **Protected Routes**: All routes except auth endpoints require valid JWT
- **Custom Validators**: Email validation to prevent temporary/disposable emails

## 🧪 Testing with cURL

### Register and Login
```bash
# Register
curl -X POST https://localhost:5001/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "firstname": "Jane",
    "lastname": "Smith",
    "email": "jane@example.com",
    "password": "SecurePass123",
    "age": 30
  }'

# Login
curl -X POST https://localhost:5001/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "jane@example.com",
    "password": "SecurePass123"
  }'
```

### Access Protected Endpoint
```bash
# Get all authors (requires token)
curl -X GET https://localhost:5001/api/authors \
  -H "Authorization: Bearer YOUR_JWT_TOKEN_HERE"
```

## 📦 NuGet Packages

- `Microsoft.AspNetCore.Authentication.JwtBearer` (9.0.10)
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (9.0.9)
- `Microsoft.EntityFrameworkCore` (9.0.9)
- `Microsoft.EntityFrameworkCore.SqlServer` (9.0.9)
- `BCrypt.Net-Next` (4.0.3)
- `Microsoft.AspNetCore.OpenApi` (9.0.9)

## 🚦 Getting Started Guide

1. **Start the application** and navigate to the OpenAPI endpoint in development mode
2. **Register a new user** via `/api/auth/register`
3. **Copy the JWT token** from the response
4. **Use the token** in subsequent requests to access protected endpoints
5. Token expires after 60 minutes (configurable in `appsettings.json`)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is licensed under the MIT License.

## 👥 Author

Your Name - Library Management System

## 🐛 Known Issues

- Make sure to update the JWT secret key in production
- Ensure SQL Server connection string is properly configured
- Token expiration time can be adjusted in `appsettings.json`

## 📞 Support

For issues and questions, please open an issue on the repository.
