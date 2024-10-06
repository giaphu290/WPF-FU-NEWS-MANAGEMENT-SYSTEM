FUNewsManagementSystem is a News Management System (NMS) that I developed to help educational institutions and universities efficiently manage, organize, and publish news. This system provides tools for managing news articles, user accounts, categories, and tags, thereby optimizing communication processes and improving engagement with the community.

Key Features:
Account Management: Supports roles such as Admin, Staff, and Lecturer, allowing for login, management, and editing of account information.

- Admin can create statistical reports based on article creation dates and sort data in descending order.

- News Article Management: Allows Staff to create, edit, search, and delete articles. Articles can be tagged and linked to a category, and each article has an active or inactive status.

- Category Management: Admin can manage categories, deleting them only if there are no articles associated with them.

- Article Tag Management: Staff can add or remove tags from articles, with each tag being linked to only one article at a time.

- Statistics and Reporting: Admin can generate statistical reports on the number of articles within a specific timeframe, allowing for analysis of news posting activities.

Technologies Used:

- Windows Presentation Foundation (WPF) for building the user interface.

- Entity Framework Core for handling CRUD operations with the SQL Server database.

- MVVM pattern to separate the interface from business logic, ensuring extensibility and maintainability.

- Repository pattern and Singleton pattern for managing data and database connections.

- 3-Layer architecture to clearly delineate the layers of the interface, business logic, and data access, enhancing the system's maintainability.

The project is developed using .NET6 and SQL Server, ensuring the necessary security and performance features required for a professional news management system.