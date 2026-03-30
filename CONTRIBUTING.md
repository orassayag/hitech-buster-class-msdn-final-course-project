# Contributing

Contributions to this project are [released](https://help.github.com/articles/github-terms-of-service/#6-contributions-under-repository-license) to the public under the [project's open source license](LICENSE).

Everyone is welcome to contribute to this project. Contributing doesn't just mean submitting pull requests—there are many different ways for you to get involved, including answering questions, reporting issues, improving documentation, or suggesting new features.

## How to Contribute

### Reporting Issues

If you find a bug or have a feature request:
1. Check if the issue already exists in the GitHub Issues
2. If not, create a new issue with:
   - Clear title and description
   - Steps to reproduce (for bugs)
   - Expected vs actual behavior
   - Your environment details (OS, .NET version, Visual Studio version)

### Submitting Pull Requests

1. Fork the repository
2. Create a new branch for your feature/fix:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Make your changes following the code style guidelines below
4. Test your changes thoroughly
5. Commit with clear, descriptive messages
6. Push to your fork and submit a pull request

### Code Style Guidelines

This project uses:
- **C#** with .NET Framework
- **ASP.NET Web Forms** for UI
- **LINQ-to-SQL** for data access
- **JavaScript (ES5)** for client-side interactions

Before submitting:
- Ensure the solution builds without errors in Visual Studio
- Test all affected pages and functionality
- Verify database queries work correctly
- Check for any security vulnerabilities (SQL injection, XSS, etc.)

### Coding Standards

1. **Naming conventions**: Follow C# naming conventions (PascalCase for classes/methods, camelCase for local variables)
2. **Security**: Always use parameterized queries, validate user input, and sanitize outputs
3. **Error handling**: Include proper try-catch blocks and user-friendly error messages
4. **Code organization**: Keep code-behind files clean and focused
5. **Comments**: Add XML documentation comments for public methods
6. **Database**: Use LINQ-to-SQL for all database operations

### Adding New Features

When adding new features:
1. Create appropriate database tables/columns in the SQL schema
2. Update the LINQ-to-SQL model (`Dal/VideoLibDB.dbml`)
3. Add ASPX pages in `VideoLib/` folder
4. Implement business logic in code-behind or `App_Code/` classes
5. Update master page if navigation changes
6. Test thoroughly with different user roles

### Database Changes

When modifying the database:
1. Document schema changes
2. Update the LINQ-to-SQL model
3. Ensure backward compatibility if possible
4. Test all affected queries

### Security Considerations

This is a legacy application built in 2009. When contributing:
- Update any deprecated security practices
- Use modern authentication/authorization where possible
- Validate and sanitize all user inputs
- Prevent SQL injection by using parameterized queries
- Protect against XSS attacks
- Implement proper session management

## Questions or Need Help?

Please feel free to contact me with any question, comment, pull-request, issue, or any other thing you have in mind.

* Or Assayag <orassayag@gmail.com>
* GitHub: https://github.com/orassayag
* StackOverflow: https://stackoverflow.com/users/4442606/or-assayag?tab=profile
* LinkedIn: https://linkedin.com/in/orassayag

Thank you for contributing! 🙏
