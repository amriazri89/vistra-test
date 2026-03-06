# VistraTest – ASP.NET Core MVC Assessment

## Project Structure

```
VistraTest/
├── database_setup.sql                          ← Run this first in SSMS
├── Controllers/
│   ├── EmployeeController.cs                   ← Question 1
│   └── DynamicControlsController.cs            ← Question 2
├── Models/
│   └── EmployeeBiodata.cs
├── Views/
│   ├── Employee/
│   │   └── Index.cshtml                        ← Question 1 View
│   └── DynamicControls/
│       └── Index.cshtml                        ← Question 2 View
├── appsettings.json                            ← Connection string here
├── Program.cs                                  ← Routing config here
└── README.md
```

---

## Setup Instructions

### Step 1 — Install NuGet Package
Open **Tools → NuGet Package Manager → Package Manager Console** and run:
```
Install-Package Microsoft.Data.SqlClient
```

### Step 2 — Run the SQL Script
- Open **SSMS**
- Connect to your SQL Server (local or RDS)
- Open and run `database_setup.sql`
- You should see `VistraDB` created with 5 records

### Step 3 — Update Connection String
Edit `appsettings.json`:

**For local SQL Server:**
```json
"DefaultConnection": "Server=localhost;Database=VistraDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
```

**For AWS RDS:**
```json
"DefaultConnection": "Server=mydb.xxxxxxxx.us-east-1.rds.amazonaws.com;Database=VistraDB;User Id=admin;Password=YourPassword;TrustServerCertificate=True;"
```

### Step 4 — Copy Files
Replace/add files into your existing VistraTest project:

| File | Destination |
|------|-------------|
| `EmployeeController.cs` | `Controllers/` |
| `DynamicControlsController.cs` | `Controllers/` |
| `EmployeeBiodata.cs` | `Models/` |
| `Views/Employee/Index.cshtml` | `Views/Employee/` (create folder) |
| `Views/DynamicControls/Index.cshtml` | `Views/DynamicControls/` (create folder) |
| `Program.cs` | Root (replace existing) |
| `appsettings.json` | Root (replace existing) |

### Step 5 — Run
Press **F5** or run in terminal:
```bash
dotnet run
```

---

## URLs
```
http://localhost:XXXX/Employee/Index       ← Question 1: Employee List
http://localhost:XXXX/DynamicControls      ← Question 2: Dynamic Controls
```

---

## Question 1 Logic
- Filters names starting with **A**, **G**, or **V**
- Filters birth date in **Q1** (January – March)
- From sample data: **Anders Ngo** (born 05 Feb) is the only match

---

## Upload to GitHub
```bash
git init
git add .
git commit -m "Vistra ASP.NET Core MVC Assessment - Amri"
git remote add origin https://github.com/YOUR_USERNAME/vistra-test.git
git push -u origin main
```
