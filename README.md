# Cinema Management System

A comprehensive cinema management system built with Windows Forms (.NET Framework) throughout the semester.

## Technologies

| Component | Technology |
|-----------|-----------|
| **Language** | C# |
| **Framework** | .NET 8.0 |
| **UI** | Windows Forms |
| **Database** | Microsoft SQL Server 2019+ |
| **Architecture** | 3-Tier Architecture |

## Architecture Overview

**3-Tier Architecture Pattern:**

- **UI Layer (Presentation)** - `Form.cs` files
  - User interface components
  - Consistent theming via ThemeManager

- **BLL (Business Logic Layer)** - `*BLL.cs` files
  - Business rules and validation
  - Central processing hub

- **DAL (Data Access Layer)** - `*DAL.cs` files
  - Database communication using ADO.NET
  - Raw SQL command execution

- **Model** - POCOs (Plain Old CLR Objects)
  - Data structure definitions

## Features

### Staff Functions
- Ticket sales
- Food & beverage sales
- Apply vouchers/promotions

### Admin Functions
- Staff management
- Movie management
- Cinema management
- Food supply management
- Voucher/promotion management