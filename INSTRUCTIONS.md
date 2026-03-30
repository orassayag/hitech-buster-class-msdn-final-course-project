# Instructions

## Setup Instructions

1. Install prerequisites:
   - Visual Studio 2013 or higher (Visual Studio 2019/2022 recommended)
   - .NET Framework 4.0 or higher
   - SQL Server 2008 or higher (or SQL Server Express)

2. Clone the repository:
   ```bash
   git clone <repository-url>
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

## Troubleshooting

**Database connection errors:**
- Verify SQL Server is running
- Check connection string in `web.config` and `Dal/app.config`
- Ensure database exists and user has permissions

**Build errors:**
- Clean and rebuild the solution
- Restore NuGet packages if any
- Check all project references

**LINQ-to-SQL errors:**
- Regenerate the LINQ-to-SQL model if database schema changed
- Rebuild the Dal project

## Security Notes

This application was built in 2009 as a student project. Before deploying to production:
- Update authentication to modern standards (ASP.NET Identity)
- Implement proper password hashing (bcrypt/Argon2)
- Add CSRF protection
- Implement rate limiting
- Add input validation and output encoding
- Update to HTTPS only
- Review and update all security practices

## Author

* **Or Assayag** - *Initial work* - [orassayag](https://github.com/orassayag)
* Or Assayag <orassayag@gmail.com>
* GitHub: https://github.com/orassayag
* StackOverflow: https://stackoverflow.com/users/4442606/or-assayag?tab=profile
* LinkedIn: https://linkedin.com/in/orassayag
