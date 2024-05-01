# event-management-system-.net
This is an Event Management System built in Asp .Net Core 8.0

## Steps.

1. Create an MVC project.
2. Install Packages:
   - `Microsoft.VisualStudio.Web.CodeGeneration.Design 8.0.2`
3. Add new Scafolded Item - Identity.
   - Login
   - Logout
   - Register
   - ResetPassword
4. New folder will be created - Areas
5. Add `app.MapRazorPages();` to `Program.cs` to map razor elements like Login and Register to our Home page.
6. Update `IdentityDBContect.cs` to add one more class - Username.
7. Configure and connect Rider IDE with PostgreSQL.
8. Configure the Connection String.
9. Add Migration and Update Database.
10. Created Identity.
11. Now moving on to EMS.
