# 📚 Library Management System

A comprehensive web-based Library Management System built with ASP.NET Core, designed to streamline library operations including book inventory management, customer registration, and sales tracking.

## 🌟 Features

### 📖 Book Management
- **Complete CRUD Operations**: Add, view, edit, and delete books
- **Comprehensive Book Details**: Title, Author, Category, Published Year, Quantity, Price, and Description
- **Inventory Tracking**: Real-time quantity management
- **Data Validation**: Robust input validation with custom error messages

### 👥 Customer Management
- **Customer Registration**: Secure customer account creation
- **Profile Management**: Edit and update customer information
- **Email Validation**: Built-in email format validation
- **Customer Database**: Centralized customer information storage

### 💰 Sales Management
- **Sales Recording**: Track book sales with quantity and pricing
- **Transaction History**: Complete sales audit trail
- **Price Calculation**: Automated total price computation
- **Date Tracking**: Timestamped sales records

### 🎨 User Interface
- **Responsive Design**: Mobile-friendly interface using TailwindCSS
- **Modern UI**: Clean and intuitive user experience
- **Form Validation**: Real-time client and server-side validation
- **Error Handling**: User-friendly error messages and exception handling

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core (.NET 9.0)
- **Architecture**: Model-View-Controller (MVC)
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Language**: C#

### Frontend
- **CSS Framework**: TailwindCSS
- **Template Engine**: Razor Views
- **JavaScript**: Vanilla JS with jQuery
- **Validation**: jQuery Validation & Unobtrusive Validation

### Development Tools
- **IDE**: Visual Studio / VS Code
- **Package Manager**: NuGet, npm
- **Version Control**: Git
- **Build Tool**: .NET CLI

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB, Express, or Full)
- [Node.js](https://nodejs.org/) (for TailwindCSS)
- [Git](https://git-scm.com/)

## 🚀 Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/library-management-system.git
cd library-management-system
```

### 2. Navigate to Project Directory
```bash
cd LibraryManagementSystem
```

### 3. Configure Database Connection
Update the connection string in `Data/ApplicationDbContext.cs`:
```csharp
optionsBuilder.UseSqlServer("Your_Connection_String_Here");
```

### 4. Install Dependencies
```bash
# Install .NET packages
dotnet restore

# Install npm packages for TailwindCSS
npm install
```

### 5. Database Migration
```bash
# Create and apply migrations
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 6. Build CSS (TailwindCSS)
```bash
# Development mode (with watch)
npm run dev

# Production build
npm run build-css-prod
```

### 7. Run the Application
```bash
dotnet run
```

The application will be available at:
- **HTTPS**: `https://localhost:5001`
- **HTTP**: `http://localhost:5000`

## 🎯 Usage

### Managing Books
1. Navigate to **Books** section
2. Click **"Add New Book"** to create a new book entry
3. Fill in the required details (Title, Author, Category, etc.)
4. Use **Edit** to modify existing books
5. Use **Delete** to remove books from inventory

### Managing Customers
1. Go to **Customers** section
2. Click **"Register New Customer"**
3. Enter customer details and email
4. View customer list and manage profiles

### Recording Sales
1. Access **Sales** section
2. Create new sale records
3. Select customers and books
4. Record quantities and calculate totals
5. View sales history and reports

## 🔧 Configuration

### Database Configuration
The application uses SQL Server by default. To change the database provider:

1. Update `ApplicationDbContext.cs`
2. Install appropriate Entity Framework provider
3. Update connection string format

## 🐛 Known Issues

- Database connection string is hardcoded (should be moved to configuration)
- No authentication/authorization implemented
- Limited reporting features


## 🙏 Acknowledgments

- ASP.NET Core Documentation
- Entity Framework Core Documentation
- TailwindCSS Documentation
- Bootstrap Icons
- jQuery Validation

---
