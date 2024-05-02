# Event Management System in .Net Core MVC

This is an Event Management System built in Asp .Net Core 8.0 and PostgreSQL.

# Table of Contents

- [Introduction](#introduction)
- [Models](#models)
- [Controllers](#controllers)
- [Views](#views)
- [Installation](#installation)
- [Security](#security)
- [Conclusion](#conclusion)

---

## Introduction
This document provides a comprehensive overview of the Event Management System built in Asp .Net Core MVC. The system allows users to manage events and categories, with authentication implemented to ensure data security.

## Models
### AppUser
- Inherits from `IdentityUser`.
- Additional properties: Name, Address.

### Event
- Represents an event.
- Properties include: EventID, EventName, Category, StartDate, EndDate, Venue, Status, BookingUserName.

### Category
- Represents a category for events.
- Properties include: CategoryID, CategoryName, Description, PricePerHour, PricePerDay, IsActive, MaxCapacity.

## Controllers
- **AccountController**: Manages user authentication, including login, register, and logout functionalities.
- **EventsController**: Handles CRUD operations for events.
- **CategoriesController**: Handles CRUD operations for categories.

## Database

### PostgreSQL 

Event Management System utilizes PostgreSQL as its relational database management system. PostgreSQL offers robust features, reliability, and scalability, making it an ideal choice for storing and managing event-related data.

PostgreSQL enables efficient data handling, ACID compliance, and support for complex queries, ensuring the system's stability and performance. Additionally, PostgreSQL's support for JSON data types allows for flexible schema design, accommodating various event attributes and configurations.

By leveraging PostgreSQL, the Event Management System ensures data integrity, scalability, and optimal performance, providing users with a seamless experience while managing events and categories.

## Views
### **Login**: Allows users to log in to the system.
![Login View](https://imgur.com/vDfZeQC.png)
### **Register**: Allows users to create a new account.
![Register View](https://imgur.com/1blvc61.png)
### **Landing**: Home page of the application.
![Landing View](https://imgur.com/lhBifNp.png)
### **Events**: Displays a list of events and provides options for CRUD operations.
![Events View](https://imgur.com/UAQwKBB.png)
### **Categories**: Displays a list of categories and provides options for CRUD operations.
![Categories View](https://imgur.com/6OXcIdv.png)
### **Create**: Allows users to create an event and category.
![Create View](https://imgur.com/IgHNXWV.png)
### **Edit**: Allows users to edit event and category details.
![Edit View](https://imgur.com/mrWne2h.png)
### **Details**: Shows detailed information about a specific event or category.
![Details View](https://imgur.com/3crJcrn.png)
### **Delete**: Allows users to delete events and categories.
![Delete View](https://imgur.com/bIuKP8y.png)

---
## Installation

### Clone Repository
To clone the repository, run the following command:

```bash
git clone https://github.com/abhie7/event-management-system-dotnet-core.git
```

### Install Dependencies
1. Install the required NuGet packages:
   - `Microsoft.AspNetCore.EntityFramework ≥ 8.0.4`
   - `Microsoft.AspNetCore.Identity ≥ 8.0.4`
   - `Microsoft.EntityFrameworkCore.Tools ≥ 8.0.4`
   - `Microsoft.EntityFrameworkCore.Design ≥ 8.0.4`
   - `Microsoft.VisualStudio.Web.CodeGenerators.Design ≥ 8.0.2`
   - `Npgsql.EntityFrameworkCore.PostgreSQL ≥ 8.0.2`
2. Create a new ASP.Net Core MVC project.
3. Follow the steps outlined in the project's README.md file for setting up the database connection and initial configurations.

## Security
- Users must log in before accessing the tables to manage events and categories.
- Authentication is handled using ASP.NET Core Identity.

## Conclusion
The Event Management System provides a user-friendly interface for managing events and categories securely. With features such as authentication and CRUD operations, it offers a robust solution for event organization and management.

---
