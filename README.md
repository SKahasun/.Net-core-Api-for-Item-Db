# 🛒 Items REST API — ASP.NET Core + Angular

A full-stack inventory management application with an **ASP.NET Core Web API** backend and **Angular** frontend. Manage items with full CRUD operations backed by SQL Server via Entity Framework Core.

---

## 📋 Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Database](#database)
- [Configuration](#configuration)
- [CORS](#cors)

---

## ✨ Features

- ✅ Full **CRUD** operations for inventory items
- ✅ **Auto-seeding** of initial data on first run
- ✅ **SQL Server** database via Entity Framework Core
- ✅ **CORS** configured for Angular dev server (`localhost:4200`)
- ✅ **OpenAPI** (Swagger) support in development mode
- ✅ Reference loop handling with **Newtonsoft.Json**

---

## 🛠️ Tech Stack

| Layer      | Technology                        |
|------------|-----------------------------------|
| Backend    | ASP.NET Core Web API (.NET 8+)    |
| ORM        | Entity Framework Core             |
| Database   | Microsoft SQL Server              |
| Frontend   | Angular (localhost:4200)          |
| Serializer | Newtonsoft.Json                   |
| API Docs   | OpenAPI / Swagger                 |

---

## 📁 Project Structure

```
├── Controllers/
│   └── ItemsController.cs   # REST API controller (CRUD)
├── Models/
│   ├── DbModels.cs           # Item model & DbContext
├── Program.cs                # App bootstrap, DI, middleware
└── appsettings.json          # Connection string config
```

---

## ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (LocalDB, Express, or full)
- [Node.js + Angular CLI](https://angular.io/cli) *(for frontend)*
- [Visual Studio 2026](https://visualstudio.microsoft.com/) or VS Code

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/SKahasun/.Net-core-Api-for-Item-Db
cd .Net-core-Api-for-Item-Db
```

### 2. Configure the Database

Open `appsettings.json` and update the connection string:

```json
{
  "ConnectionStrings": {
    "appCon": "Server=YOUR_SERVER;Database=ItemsDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Run the API

```bash
dotnet restore
dotnet run
```

The API will start at `https://localhost:5018` (or the port configured in `launchSettings.json`).

> 💡 **Note:** The database and tables are created automatically on first run using `EnsureCreated()`. Sample data is seeded if the Items table is empty.

### 4. Run the Angular Frontend

```bash
cd ClientApp   # or your Angular project folder
npm install
ng serve
```

Angular dev server runs at `http://localhost:4200`.

---

## 📡 API Endpoints

Base URL: `https://localhost:5018/api`

| Method   | Endpoint          | Description          |
|----------|-------------------|----------------------|
| `GET`    | `/api/Items`      | Get all items        |
| `GET`    | `/api/Items/{id}` | Get item by ID       |
| `POST`   | `/api/Items`      | Create a new item    |
| `PUT`    | `/api/Items/{id}` | Update an item       |
| `DELETE` | `/api/Items/{id}` | Delete an item       |

### Sample Request Body (POST / PUT)

```json
{
  "itemName": "Widget Pro",
  "unitPrice": 19.99,
  "stock": 150
}
```

### Sample Response

```json
{
  "itemId": 1,
  "itemName": "Widget Pro",
  "unitPrice": 19.99,
  "stock": 150
}
```

---

## 🗄️ Database

### Item Model

| Column      | Type         | Constraints             |
|-------------|--------------|-------------------------|
| `ItemId`    | `int`        | Primary Key, Auto-increment |
| `ItemName`  | `nvarchar(40)` | Required              |
| `UnitPrice` | `money`      | Required                |
| `Stock`     | `int`        | Required                |

### Seed Data

On first run, the following items are inserted automatically:

| ItemName | UnitPrice | Stock |
|----------|-----------|-------|
| Item 1   | $10.00    | 100   |
| Item 2   | $20.00    | 200   |
| Item 3   | $30.00    | 300   |

---

## ⚙️ Configuration

Key settings in `Program.cs`:

- **`EnsureCreated()`** — Creates the DB schema automatically (no migrations needed for development)
- **Newtonsoft.Json** — Configured to handle reference loops and preserve object references
- **OpenAPI** — Enabled in the Development environment at `/openapi`

---

## 🌐 CORS

CORS is configured to allow requests from:

- `http://localhost:4200` — Angular development server
- `http://localhost:5018` — API server

Any origin, method, and header are permitted for development convenience. **Remember to restrict CORS rules before deploying to production.**
