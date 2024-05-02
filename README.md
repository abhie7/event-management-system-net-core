# Event Management System in .Net Core MVC
This is an Event Management System built in Asp .Net Core 8.0 and PostgreSQL
---
## Steps.

1. Install the required NuGet packages which include EF Core, EF Core Identity, Microsoft.EntityFrameworkCore.Tools and Identity Model.
   - `Microsoft.AspNetCore.EntityFramework ≥ 8.0.4`
   - `Microsoft.AspNetCore.Identity ≥ 8.0.4`
   - `Microsoft.EntityFrameworkCore.Tools ≥ 8.0.4`
   - `Microsoft.EntityFrameworkCore.Design ≥ 8.0.4`
   - `Microsoft.VisualStudio.Web.CodeGenerators.Design ≥ 8.0.2`
   - `Npgsql.EntityFrameworkCore.PostgreSQL ≥ 8.0.2`
3. Create a new ASP.Net Core MVC project.
4. Add a new folder named Data and a class named `DBContext` that inherits from `IdentityDbContext`. This class will manage database operations.
5. Create a new model named `AppUser` that inherits from `IdentityUser`. `AppUser` will have two additional properties, Name and Address.
6. Configure the connection string in `appsettings.cs`.
7. Register the `DbContext` in the `Program.cs` file.
8. Add Migrations and update the database using the Package Manager Console.
9. Create two new view models, `LoginVM` and `RegisterVM`. `LoginVM` will have Username, Password and RememberMe properties. `RegisterVM` will have Name, Email, Password, ConfirmPassword and Address properties.
10. Create a new controller named `AccountController`. This controller will have Login, Register and Logout functionalities.
11. Design Login and Register views using Razor Pages.
12. Implement the functionalities for Login and Register in the `AccountController`. `SignInManager` and `UserManager` classes are used to perform the login and register operations.
13. Add client-side validation for the Login and Register views.
14. Create a new partial view named LoginPartial to display the login and logout functionality based on the user being signed in or not.
15. Implement the logout functionality in the `AccountController`.
16. Created a table named `eventstable` in my PostgreSQL database.
17. Used the connection string to connect my ASP.Net Core application and scaffolded the eventstable table. This generated an `eventstable.cs` model class and an `EventsDbContext.cs` class.
18. Scaffolded an MVC Controller named `EventsController` which includes views for managing events.
19. Built the user interface (UI) using Razor Pages and Bootstrap for styling.
20. Added a search function for users to find events.
---
