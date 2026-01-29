o	This project was built throughout the semester using Window Forms App (.NET Framework) as the template. From there, we started to plan out the workflow and project structure. The Cinema Management System aims to streamline operations using modern technology such as C#, .NET 8.0, and SQL Server. Its 3-Tier Architecture enhances modularity and maintainability across various functions.
o	Technologies Table
Language	C#
Framework	.NET 8.0
User Interface (UI)	Windows Forms
Database	Microsoft SQL Server 2019 or newer
Architecture	A well-defined 3-Tier Architecture.
•	UI (Presentation Layer): Form classes that the user interacts with.
•	BLL (Business Logic Layer): Handles business rules, logic, and data validation.
•	DAL (Data Access Layer): Responsible for accessing and manipulating the database.
Model	POCOs (Plain Old CLR Objects) that define the data structures.

o	About 3-Tier Architecture:
In this project, we applied the 3-Tier Architecture:
	UI (Form...cs): Interacts with the BLL. A dedicated ThemeManager class ensures a consistent look and feel.
	BLL (...BLL.cs): The central processing hub, handles all business logic and validation, and calls the DAL.
	DAL (...DAL.cs): The only layer that communicates with the database, using ADO.NET and raw SQL commands.
Project Functions:
These are two main individuals that have a lot of different functions:
o	Staff:
	Selling Tickets
	Choosing and Selling Food
	Add Vouchers / Promotions
o	Admin:
	Staff Managing
	Movies Managing
	Cinemas Managing
	Food Supplies Managing
	Vouchers / Promotions Managing
