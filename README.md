# VistraTest — ASP.NET Core MVC Assessment
> Vistra Malaysia Technical Assessment | Candidate: Amri | March 2026

---

## 📋 Overview

This project is a technical assessment built with **ASP.NET Core MVC** and **SQL Server**, consisting of two questions:

| # | Description | URL |
|---|-------------|-----|
| Q1 | Employee list filtered by name initial and birth quarter | `/Employee/Index` |
| Q2 | Dynamic web control generator | `/DynamicControls/Index` |

---

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core MVC (.NET 8)
- **Language:** C#
- **Database:** SQL Server (AWS RDS)
- **ORM:** Raw SQL via `Microsoft.Data.SqlClient`
- **Frontend:** Razor Views + Vanilla JavaScript
- **Hosting:** AWS EC2 (Windows Server) + AWS RDS (SQL Server)

---

## 📁 Project Structure

```
VistraTest/
├── Controllers/
│   ├── EmployeeController.cs          ← Question 1 logic
│   └── DynamicControlsController.cs   ← Question 2 logic
├── Models/
│   └── EmployeeBiodata.cs             ← Employee data model
├── Views/
│   ├── Employee/
│   │   └── Index.cshtml               ← Question 1 UI
│   └── DynamicControls/
│       └── Index.cshtml               ← Question 2 UI
├── appsettings.json                   ← Connection string
├── Program.cs                         ← App entry point & routing
├── database_setup.sql                 ← DB schema + seed data
└── README.md
```

---

## ❓ Question 1 — Employee List

**Requirement:**
Display employees from `employee_biodata` where:
- Name starts with **A**, **G**, or **V**
- Birth date falls in **Q1 (January – March)**

**SQL Logic:**
```sql
SELECT employee_no, employee_name, birth_date
FROM   employee_biodata
WHERE  (   employee_name LIKE 'A%'
        OR employee_name LIKE 'G%'
        OR employee_name LIKE 'V%')
  AND  MONTH(birth_date) BETWEEN 1 AND 3
ORDER BY employee_name;
```

**Expected Result from sample data:**

| Employee No | Employee Name | Birth Date |
|-------------|---------------|------------|
| 00004 | Anders Ngo | 05 Feb 1986 |

> Alex Song is born in December (Q4) so he does not qualify despite starting with "A".

---

## ❓ Question 2 — Dynamic Control Generator

**Requirement:**
A web page that dynamically generates controls based on user selection.

**Supported control types:**
- TextBox, CheckBox, RadioButton, Button
- DropDownList, TextArea, Password, Email

**How it works:**
1. User selects a control type from the dropdown
2. User enters the number of controls to generate (1–20)
3. Clicking **Generate Controls** renders them on the page instantly via JavaScript

---

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 or VS Code
- .NET 8 SDK
- SQL Server or AWS RDS (SQL Server)
- SSMS (SQL Server Management Studio)

### Step 1 — Clone the repo
```bash
git clone https://github.com/amriazri89/vistra-test.git
cd vistra-test
```

### Step 2 — Install dependencies
```bash
dotnet add package Microsoft.Data.SqlClient
```

### Step 3 — Set up the database
- Open **SSMS** and connect to your SQL Server
- Open and run `database_setup.sql`
- This creates `VistraDB` database with `employee_biodata` table and 5 seed records

### Step 4 — Update connection string
Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=VistraDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  }
}
```

| Environment | Server value |
|-------------|-------------|
| Local | `localhost` or `localhost\SQLEXPRESS` |
| AWS RDS | `mydb.xxxxxxxx.us-east-1.rds.amazonaws.com` |

### Step 5 — Run the app
```bash
dotnet run
```

Then open your browser:
```
http://localhost:5000/Employee/Index       ← Question 1
http://localhost:5000/DynamicControls      ← Question 2
```

---

## ☁️ AWS Deployment

| Service | Purpose |
|---------|---------|
| EC2 (Windows Server) | Hosts the ASP.NET Core app via IIS |
| RDS (SQL Server) | Managed database |

**Key configuration:**
- EC2 Security Group: open port **80** (HTTP)
- RDS Security Group: open port **1433** from EC2 Security Group only
- Use `User Id` + `Password` in connection string (not Windows Auth)

---

## 👤 Author

**Amri** — [github.com/amriazri89](https://github.com/amriazri89)