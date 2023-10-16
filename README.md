# BillingSystem is an example ASP.NET MVC application that demonstrate the "code first" approach to working with databases using Entity Framework.
# Create the application:
File menu>New>Project>select ASP.NET Core Web App (Model-View-Controller)>Next>Project name "BillingSystem">Next>select Framework ".NET 7.0", select Authentication type "none" and Configure for HTTPS>Create.
# Create Model class "BillRecord":
Right-click on the "Models" folder>Add>New Item>select "Class" and name it "BillRecord.cs".
# Add the connection string to be able to connect to MariaDB server:
Navigate to the "appsettings.json" file in the Solution Explorer. 
In the connection string, you put the name of the database "billingsysdb" even though it is not existing yet. 
Also enter the password that was used in the MariaDB setup instead of the one provided in this example application.
# Add a few packages to the solution of the application to enable using EF and handle the connection to the database. 
Right-click on the solution>Manage NuGet Packages for Solution>Browse Tab. 
Here, there are three important packages to search for and install: "Microsoft.EntityFrameworkCore", "Microsoft.EntityFrameworkCore.Design", "Microsoft.EntityFrameworkCore.Tools", and "Pomelo.EntityFrameworkCore.MySql".
# Create the class "BillingContext" as derived from DbContext class:
Right-click on the "Models" folder>Add>New Item> nane it "BillingContext.cs". 
The class is derived from DbContext class, which is a primary class in EF Core functionality for interacting with the database in an object-oriented manner without having to write raw SQL queries.
The "DbSet" represents a collection of all the "BillRecord" entities in the database, essentially representing the "BillRecords" table in the database. 
Through this property "DbSet", you can perform operations like querying the table, adding new records, or deleting existing ones.
# Create a new controller "BillingController":
Right-click on “Controllers” folder>Add>Controller>name it "BillingController.cs".
This controller will interact with the “BillingContext” to insert and display data.
# Create folder "Billing" under "Views". 
# Create new views in the created "Billing" folder.
Right-click on the "Billing" folder>Add>View>select "Razor View - Empty">name it "Index.cshtml" and call the model "BillRecord.cs" in it.
Then set the layout of the form to use for inserting data into the database.
Create another view and name it "Records.cshtml" to display the inserted records and call the model "BillRecord.cs" in it.
# Perform Dependency Injection (DI):
Navigate to "Program.cs" in the Solution Explorer. Here, you configure the connection to the database server and register DbContext as a service through the "BillingContext.cs" class.
# Now, before you run the application, there are two important commands you need to run in the "Package Manager Console":
Go to Tools menu in Visual Studio>NuGet Package Manager>Package Manager Console.
Type the following commands to create the "billingsysdb" database and "billrecords" table:
Command1: Add-Migration InitialCreate (Then press Enter)
# What happens when you run "Add-Migration InitialCreate"?
1.	EF Core checks the current state of your models and compares them to the last migration (if any exists). 
2.	It calculates the differences and determines what changes need to be made to the database to make the database schema match the current state of the models.
3.	EF Core then generates a migration file with a name like "XXXXXXXXXXXXXX_InitialCreate.cs" (where "XXXXXXXXXXXXXX" is a timestamp of when the migration was created). This file contains the operations necessary to apply the changes to the database.
4.	This migration file will be placed in a "Migrations" folder in your project. If you open this file, you'll see C# code that represents the changes. This code will include methods like "Up()" and "Down()". The "Up()" method has the changes to apply the migration (e.g., create tables, add columns), and the "Down()" method has the reverse of those changes to undo the migration.
# Note that: 
After creating the migration with "Add-Migration", you would typically apply the migration to the database using the "Update-Database" command. This command will execute the code in the migration file against your database, applying the changes.
Note that the "Add-Migration" command does not make any changes to your database. It merely creates a set of instructions on how to update the database. The actual changes to the database are made when you use the "Update-Database" command.

Command2: Update-Database (Then press Enter)
# What happens when you run "Update-Database"? 
1.	Checks for Pending Migrations: EF Core looks at the list of migrations that have been added to your project (these are typically in the "Migrations" folder) and determines which ones have not yet been applied to the database.
2.	Applies the Migrations: For each pending migration, EF Core runs the code inside the "Up()" method of the migration. This code contains the operations necessary to change the database schema to match the model changes represented by the migration. This might include creating new tables, altering existing tables, adding or dropping columns, creating indices, and other database operations.
3.	Updates the "__EFMigrationsHistory" Table: After successfully applying a migration, EF Core records this in a special table in the database called "__EFMigrationsHistory". This table keeps track of which migrations have been applied, allowing EF Core to determine pending migrations in the future.
# Now if you go the database server you will find the database and the table created!


