# Setup and Usage Instructions

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Initial Setup](#initial-setup)
3. [Install Dependencies](#install-dependencies)
4. [System Requirements](#system-requirements)
5. [Setup Instructions](#setup-instructions)
6. [Database Configuration](#database-configuration)
7. [Building the Project](#building-the-project)
8. [Running the Application](#running-the-application)
9. [Development Commands](#development-commands)
10. [Available Commands](#available-commands)
11. [Running Scripts](#running-scripts)
12. [Application Features](#application-features)
13. [Project Structure](#project-structure)
14. [Key Classes and Components](#key-classes-and-components)
15. [Configuration](#configuration)
16. [Testing](#testing)
17. [Best Practices](#best-practices)
18. [Extending the Application](#extending-the-application)
19. [Documentation](#documentation)
20. [External Resources](#external-resources)
21. [Troubleshooting](#troubleshooting)
22. [Security Notes](#security-notes)
23. [Version](#version)
24. [Last Updated](#last-updated)
25. [Author](#author)

## Prerequisites

### System Requirements

- **Visual Studio**: 2013 or higher (2019/2022 recommended)
- **.NET Framework**: 4.0 or higher
- **SQL Server**: 2008 or higher (or SQL Server Express)
- **IIS or IIS Express**: Included with Visual Studio
- **Operating System**: Windows (for Visual Studio development)

### Knowledge Prerequisites

- Basic understanding of ASP.NET Web Forms
- Familiarity with C# programming
- Basic knowledge of SQL Server databases

## Initial Setup

### Step-by-Step Initial Setup

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/orassayag/hitech-buster-class-msdn-final-course-project.git
   cd hitech-buster-class-msdn-final-course-project
   ```

2. **Open the Solution:**
   - Navigate to `VideoLib/` folder
   - Open `VideoLib.sln` in Visual Studio

3. **Configure the Database:**
   - Create a database named `VideoLibDB` in SQL Server
   - Update connection string in `VideoLib/web.config`
   - Update connection string in `Dal/app.config`

4. **Build the Solution:**
   - Build `Dal` project first (Data Access Layer)
   - Build `VideoLib` project (Main Application)

5. **Run the Application:**
   - Press `F5` or click "Start Debugging"

## Install Dependencies

### Required Software

1. **Visual Studio**: Download and install from [Visual Studio website](https://visualstudio.microsoft.com/)
2. **SQL Server**: Download and install from [SQL Server website](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
3. **.NET Framework**: Included with Visual Studio or downloadable from [Microsoft .NET website](https://dotnet.microsoft.com/)

### Project Dependencies

The project uses standard .NET Framework libraries, so no additional NuGet packages are required beyond what's included in the solution.

## System Requirements

- **Operating System**: Windows 7 or later
- **Processor**: 1.6 GHz or faster, dual-core recommended
- **RAM**: 2 GB minimum, 4 GB recommended
- **Hard Disk Space**: 5 GB minimum for Visual Studio and project files
- **Display**: 1366 x 768 or higher resolution

## Setup Instructions

1. Install prerequisites:
   - Visual Studio 2013 or higher (Visual Studio 2019/2022 recommended)
   - .NET Framework 4.0 or higher
   - SQL Server 2008 or higher (or SQL Server Express)

2. Clone the repository:
   ```bash
   git clone https://github.com/orassayag/hitech-buster-class-msdn-final-course-project.git
   cd hitech-buster-class-msdn-final-course-project
   ```

3. Open the solution:
   - Navigate to `VideoLib/` folder
   - Open `VideoLib.sln` in Visual Studio

## Database Configuration

1. **Create the database:**
   - Open SQL Server Management Studio
   - Create a new database named `VideoLibDB`
   - Run the schema creation scripts (if provided in `Dal/` folder)

2. **Update connection string:**
   - Open `VideoLib/web.config`
   - Locate the `<connectionStrings>` section
   - Update the connection string to match your SQL Server instance:
   ```xml
   <connectionStrings>
     <add name="VideoLibDBConnectionString" 
          connectionString="Data Source=YOUR_SERVER;Initial Catalog=VideoLibDB;Integrated Security=True" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

3. **Update LINQ-to-SQL connection:**
   - Open `Dal/app.config`
   - Update the connection string to match your database

## Building the Project

1. Build the Data Access Layer:
   - Right-click on `Dal` project in Solution Explorer
   - Select "Build"

2. Build the main application:
   - Right-click on `VideoLib` project
   - Select "Build"

3. Resolve any missing references if needed

## Running the Application

1. Set `VideoLib` as the startup project (if not already):
   - Right-click on `VideoLib` project
   - Select "Set as StartUp Project"

2. Press `F5` or click "Start Debugging" to run

3. The application should open in your default browser

## Development Commands

### Build Commands

- **Build Solution**: `Ctrl+Shift+B` in Visual Studio
- **Rebuild Solution**: Right-click solution → Rebuild Solution
- **Clean Solution**: Right-click solution → Clean Solution

### Debug Commands

- **Start Debugging**: `F5`
- **Start Without Debugging**: `Ctrl+F5`
- **Toggle Breakpoint**: `F9`

## Available Commands

### Visual Studio Commands

| Command | Description |
|---------|-------------|
| `Ctrl+Shift+B` | Build Solution |
| `F5` | Start Debugging |
| `Ctrl+F5` | Start Without Debugging |
| `F9` | Toggle Breakpoint |
| `F10` | Step Over |
| `F11` | Step Into |

### Database Commands

- **Open SQL Server Management Studio**: Connect to your database server
- **Execute Query**: Run SQL scripts to modify database schema or data

## Running Scripts

### Database Scripts

If database schema scripts are provided in the `Dal/` folder:
1. Open SQL Server Management Studio
2. Connect to your database server
3. Open and execute the script files

## Application Features

### User Features

**Authentication & Profile:**
- Sign up / Sign in (`20Sign-In.aspx`)
- View member details (`30MemberDetails.aspx`)
- Add subscription days (`31AddSubscriptions.aspx`)

**Movie Browsing:**
- Browse popular movies (`10Default.aspx`)
- View movies by category/type
- View movie details (`40MovieDetails.aspx`)
- See movie reviews (`34Reviews.aspx`)
- Get personalized recommendations (`35RecommendedForYou.aspx`)

**Rental Management:**
- Add movies to cart (`41AddToCart.aspx`)
- View shopping cart (`42ShowCart.aspx`)
- View currently rented movies (`33CurrentlyRented.aspx`)
- View rental history (`32RentalHistory.aspx`)
- Check rent status (`38RentStatus.aspx`)
- Join waiting list for unavailable movies (`36WaitingList.aspx`)

**Reviews:**
- Add movie reviews (`43AddReview.ascx`)
- View all reviews for a movie

### Administrative Features

**Movie Management:**
- Add new movies (`50AddMovie.aspx`)
- Add movie copies (`51AddMovieCopies.aspx`)
- Remove movies (`52RemoveMovie.aspx`)

**Reports & Analytics:**
- View movies past due date (`53PastDueDate.aspx`)
- View movies with long waiting lists (`54MoviesWithLongWaitingList.aspx`)
- View inactive movies ("dead movies") (`55DeadMovies.aspx`)
- View inactive renters (`56InactiveRenters.aspx`)
- View rental activity per month (`57RentActivityPerMonth.aspx`)

## Project Structure

```
hitech-buster-class-msdn-final-course-project/
├── Dal/                          # Data Access Layer
│   ├── VideoLib.cs              # LINQ-to-SQL entity classes
│   ├── VideoLibDB.designer.cs   # LINQ-to-SQL designer code
│   ├── VideoLibDB.dbml          # LINQ-to-SQL mapping
│   ├── Dal.csproj               # DAL project file
│   └── app.config               # DAL configuration
├── VideoLib/                     # Main web application
│   ├── App_Code/                # Business logic classes
│   │   ├── Cart.cs              # Shopping cart logic
│   │   ├── CartItem.cs          # Cart item model
│   │   ├── DataCache.cs         # Data caching layer
│   │   ├── LoggedInUser.cs      # User session management
│   │   └── CurrentTime.cs       # Time management utility
│   ├── 01VideoLib.master        # Master page template
│   ├── 10Default.aspx           # Home page
│   ├── 20Sign-In.aspx           # Authentication
│   ├── 30-39*.aspx              # User profile & rental pages
│   ├── 40-49*.aspx              # Movie details & cart pages
│   ├── 50-59*.aspx              # Admin pages
│   ├── web.config               # Application configuration
│   └── VideoLib.sln             # Solution file
└── Film/                        # Movie images/assets
```

## Key Classes and Components

### Data Access Layer (`Dal/`)
- **VideoLibDB**: LINQ-to-SQL DataContext
- **Movie, Member, Rent, Review**: Entity classes

### Business Logic (`VideoLib/App_Code/`)
- **Cart**: Shopping cart management
- **DataCache**: Cached data access wrapper
- **LoggedInUser**: User session and authentication
- **CurrentTime**: Centralized time management

### Master Page (`01VideoLib.master`)
- Common layout and navigation
- User session display
- Category navigation

## Configuration

### Application Settings (`web.config`)
Key settings you may need to configure:
- Connection strings
- Session timeout
- Authentication mode
- Custom error pages

### Time Management
The application uses `CurrentTime` class for time operations, allowing for easier testing and time manipulation.

## Testing

Manual testing checklist:
1. User registration and login
2. Browsing movies by category
3. Adding movies to cart
4. Renting movies (ensure subscription days are deducted)
5. Returning movies
6. Joining waiting lists
7. Adding reviews
8. Admin functions (add/remove movies)
9. Viewing reports

## Best Practices

### Development Best Practices

1. **Layered Architecture**: Maintain clear separation between presentation, business logic, and data access layers
2. **Code Reuse**: Use master pages and user controls to promote code reuse
3. **Centralized Logic**: Keep business logic in App_Code classes for maintainability
4. **Type Safety**: Leverage LINQ-to-SQL for type-safe database operations
5. **Caching**: Use DataCache class to improve application performance
6. **Version Control**: Use Git for version control and follow branching strategies

### Security Best Practices

> **Note**: This application was built in 2009 as a student project. Before deploying to production:

1. **Authentication**: Update to modern authentication standards like ASP.NET Identity
2. **Password Hashing**: Implement strong password hashing (bcrypt/Argon2)
3. **CSRF Protection**: Add cross-site request forgery protection
4. **HTTPS**: Enforce HTTPS for all communications
5. **Input Validation**: Implement proper input validation and output encoding
6. **SQL Injection Protection**: Already implemented via LINQ-to-SQL parameterized queries

### Database Best Practices

1. **Backups**: Regularly back up your SQL Server database
2. **Indexes**: Optimize database performance with appropriate indexes
3. **Normalization**: Follow database normalization principles
4. **Connection Management**: Properly open and close database connections

## Extending the Application

### Adding New Features

1. **New Pages**: Add new ASPX pages in the appropriate number range (user pages 30-49, admin pages 50-59)
2. **Business Logic**: Add or modify classes in `VideoLib/App_Code/`
3. **Data Access**: Update the LINQ-to-SQL model in `Dal/VideoLibDB.dbml` if schema changes are needed
4. **Navigation**: Update the master page (`01VideoLib.master`) to include links to new pages

### Database Schema Changes

1. Modify the database schema in SQL Server
2. Open `Dal/VideoLibDB.dbml` in Visual Studio
3. Update the LINQ-to-SQL model to reflect schema changes
4. Rebuild the `Dal` project

## Documentation

### Additional Documentation

- **README.md**: Project overview and features
- **CONTRIBUTING.md**: Contribution guidelines
- **LICENSE**: License information
- **Code Comments**: Look for comments in the source code for detailed explanations

### Resources for Learning

- ASP.NET Web Forms documentation
- C# programming guides
- LINQ-to-SQL tutorials
- SQL Server documentation

## External Resources

### Microsoft Documentation

- [ASP.NET Web Forms](https://docs.microsoft.com/en-us/aspnet/web-forms)
- [C# Guide](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [LINQ (Language-Integrated Query)](https://docs.microsoft.com/en-us/dotnet/csharp/linq/)
- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/)

### Learning Resources

- [Visual Studio Documentation](https://docs.microsoft.com/en-us/visualstudio/)
- [.NET Framework Documentation](https://docs.microsoft.com/en-us/dotnet/framework/)

## Troubleshooting

### Common Issues and Solutions

**Database Connection Errors:**
- Verify SQL Server is running
- Check connection string in `web.config` and `Dal/app.config`
- Ensure database exists and user has permissions

**Build Errors:**
- Clean and rebuild the solution
- Restore NuGet packages if any
- Check all project references

**LINQ-to-SQL Errors:**
- Regenerate the LINQ-to-SQL model if database schema changed
- Rebuild the Dal project

**Page Not Found Errors:**
- Verify the ASPX page exists in the correct location
- Check the URL path in the browser
- Ensure the application is running correctly

**Session Timeouts:**
- Adjust session timeout in `web.config`
- Check user authentication status

## Security Notes

This application was built in 2009 as a student project. Before deploying to production:
- Update authentication to modern standards (ASP.NET Identity)
- Implement proper password hashing (bcrypt/Argon2)
- Add CSRF protection
- Implement rate limiting
- Add input validation and output encoding
- Update to HTTPS only
- Review and update all security practices

## Version

1.0.0

## Last Updated

June 2026

## Author

- **Or Assayag** - _Initial work_ - [orassayag](https://github.com/orassayag)
- Or Assayag <orassayag@gmail.com>
- GitHub: https://github.com/orassayag
- StackOverflow: https://stackoverflow.com/users/4442606/or-assayag?tab=profile
- LinkedIn: https://linkedin.com/in/orassayag