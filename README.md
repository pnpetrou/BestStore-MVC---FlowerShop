# BestStore MVC

BestStore MVC is an ASP.NET Core web application for managing a flower store inventory. The application provides a modern, responsive interface for managing flower products with features for creating, reading, updating, and deleting flower items.

## Features



- **Flower Management**
  - View all flowers in the store
  - Add new flowers to the inventory
  - Edit existing flower details
  - Delete flowers from the inventory
  - View detailed information about each flower

- **Product Information**
  - Name
  - Category
  - Price
  - Description
  - Product Images
  - Creation Date

## Technical Stack

- **Framework**: ASP.NET Core MVC
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Frontend**: HTML, CSS, JavaScript
- **Authentication**: ASP.NET Core Identity (if implemented)

## Project Structure

```
BestStoreMVC/
├── Controllers/         # MVC Controllers
├── Models/             # Data Models
├── Views/              # Razor Views
├── Services/           # Business Logic Services
├── wwwroot/           # Static Files (CSS, JS, Images)
└── Migrations/        # Database Migrations
```

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- SQL Server
- Visual Studio 2022 or Visual Studio Code

### Installation

1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Run the following commands in the terminal:
   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

### Configuration

The application uses the following configuration in `appsettings.json`:
- Database connection string
- Application settings
- Environment-specific settings

## Development

The application follows the MVC (Model-View-Controller) pattern:
- **Models**: Define the data structure and business logic
- **Views**: Handle the presentation layer
- **Controllers**: Manage the flow between models and views

