# gFit - Backend

Welcome to the documentation for the backend of the **gFit** project! This documentation provides information about the structure, configuration, and functionality of the application's backend.

## About the Project

**gFit** is an application developed for personal trainers and users who seek practicality when practicing physical activity, to have their training in the palm of their hand, anywhere, anytime.

## Technologies Used

- ASP.NET Core 
- Entity Framework Core 
- JWT for authentication
- AWS SES

## Environment Setup

1. Clone this repository to your local machine.
2. Configure the database connection string in the `appsettings.json` file.
3. Run migrations to create the database: `dotnet ef database update`.
4. Run the application using the command: `dotnet run`.

## Features

- User Authentication
- Email Confirmation
- Password Reset

## Project Structure

The project is structured as follows:

- `Controllers`: Contains API controllers.
- `Services`: Contains application services.
- `Repositories`: Contains database access repositories.
- `Context`: Contains the database context and entities.
- `DTOs`: Contains Data Transfer Objects used to transfer information between layers.
- `Utils`: Contains auxiliary utilities.

## Contribution

Contributions are welcome! If you'd like to contribute to this project, follow these steps:

1. Fork the repository.
2. Create a new branch: `git checkout -b new-feature`.
3. Make your changes and commit: `git commit -m 'Add new feature'`.
4. Push to the branch: `git push origin new-feature`.
5. Create a Pull Request.

## Contact

If you have any questions or feedback, feel free to contact me at giovana.sant@hotmail.com.

---
