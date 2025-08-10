# PensionManagementSystem
Pension Contribution Management System for NLPC PFA. Built with .NET 7, Clean Architecture &amp; DDD. Supports employer-managed member registration, contributions, benefit calculation, validation rules, JWT auth, Hangfire jobs, and EF Core with SQL Server.

---

`markdown

🏦 Pension Management System

A secure and scalable pension management API built with ASP.NET Core and Entity Framework Core. It supports employer and member registration, JWT-based authentication, and token refresh logic.

---

 Features

- Employer registration and management  
- Member creation and updates  
- Contribution tracking  
- Benefit management  
- JWT authentication with access and refresh tokens  
- API versioning (api/v1/...)  
- Soft delete functionality  
- AutoMapper for DTO mapping  
- Unit of Work + Repository pattern  
- Swagger documentation  

---

 Technologies Used

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- AutoMapper  
- Arch.EntityFrameworkCore.UnitOfWork  
- JWT Bearer Authentication  
- Swagger / OpenAPI  

---

 Setup Instructions

1. Clone the repository

   `bash
   git clone https://github.com/your-username/pension-management-system.git
   cd pension-management-system
   `

2. Update your connection string

   In appsettings.json:

   `json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=PMS.Db;Trusted_Connection=True;"
   }
   `

3. Run migrations

   `bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   `

4. Run the application

   `bash
   dotnet run
   `

5. Access Swagger UI

   Navigate to http://localhost:5000/swagger to explore and test the API.

---

🔐 Authentication Flow

- Employers log in using their RegistrationNumber  
- On successful login, they receive:  
  - AccessToken (short-lived)  
  - RefreshToken (stored in DB, long-lived)  
- Access token is used for protected endpoints  
- Refresh token is used to renew access token when expired  

---

📁 API Endpoints

🧑‍💼 Employer

- POST /api/v1/employers — Register employer  
- GET /api/v1/employers — Get all employers  
- GET /api/v1/employers/{id} — Get employer by ID  
- PUT /api/v1/employers/{id} — Update employer  
- DELETE /api/v1/employers/{id} — Soft delete employer  

👥 Member

- POST /api/v1/members — Create member  
- GET /api/v1/members — Get all members  
- GET /api/v1/members/{id} — Get member by ID  
- PUT /api/v1/members/{id} — Update member  
- DELETE /api/v1/members/{id} — Soft delete member  

 Contribution

- POST /api/v1/contributions — Add contribution  
- GET /api/v1/contributions — Get all contributions  
- GET /api/v1/contributions/{id} — Get contribution by ID  
- PUT /api/v1/contributions/{id} — Update contribution  
- DELETE /api/v1/contributions/{id} — Soft delete contribution  

 Benefit

- POST /api/v1/benefits — Add benefit  
- GET /api/v1/benefits — Get all benefits  
- GET /api/v1/benefits/{id} — Get benefit by ID  
- PUT /api/v1/benefits/{id} — Update benefit  
- DELETE /api/v1/benefits/{id} — Soft delete benefit  

 Auth

- POST /api/v1/auth/login — Employer login  
- POST /api/v1/auth/refresh — Refresh access token  

---

 Testing

You can use Swagger or Postman to test endpoints.  
Make sure to include the access token in the Authorization header:

`
Authorization: Bearer <youraccesstoken>
`

---

 Notes

- Refresh token is stored in the Employers table  
- AutoMapper is registered via AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())  
- Unit of Work is registered via AddUnitOfWork<ApplicationDbContext>()  
- API versioning follows api/v1/... structure  

---
