# BestStore MVC

BestStore MVC is an ASP.NET Core web application for managing a flower store inventory. The application provides a modern, responsive interface for managing flower products with features for creating, reading, updating, and deleting flower items.

## Web Flow
1) Open the app
 - Visit http://localhost:5122/.

2) Go to the Flowers section
 - In the main menu, click Flowers.

3) Add a new flower
 - Click Add New Flower.
 - The Flowers/Create page appears.
 - Fill in the form and click Submit to save the new flower.
 - Click Cancel to return to the Flowers page without adding anything.

4) Edit an existing flower
 - Click Edit beside the flower you want to change.
 - On the Flower Edit page you can modify any field except ID and Creation Date.
 - Click Submit to save your changes, or Cancel to discard them.

5) Delete a flower
- Click Delete beside the flower you want to remove.
- A confirmation dialog asks “Are you sure?”
- Click OK to delete the flower, or Cancel to keep it.


## Run the app

Option 1
 • Throught GitHub got to BestStore-MVC---FlowerShop Repository
 • Click on green button Code and On drop-down menu select Open with GitHub Desktop
 • Discurd all changes if Changes exist
 • Click on Open in Visual Studio Code
 • On the Visual Studio Bar Menu click on Terminal and select the cmd (Command Prompt)
 • Run dotnet restore
 • Run dotnet run
 • Open a browser and enter http://localhost:5122/



- **Flower Management**
  - View all flowers in the store
  - Add new flowers to the inventory
  - Edit existing flower details
  - Delete flowers from the inventory
  - View detailed information about each flower



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


- .NET 6.0 SDK or later
- SQL Server
- Visual Studio 2022 or Visual Studio Code


The application follows the MVC (Model-View-Controller) pattern:
- **Models**: Define the data structure and business logic
- **Views**: Handle the presentation layer
- **Controllers**: Manage the flow between models and views
