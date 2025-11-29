# Event Registration System

This is a simple event registration system built with ASP.NET Core. It provides a web API for managing users, events, and registrations.

## Features

*   User registration and authentication (JWT-based)
*   Create, view, and manage events
*   Register users for events
*   View event registrations

## Technology Stack

*   **.NET 8** - Framework for building the application
*   **ASP.NET Core** - Web framework for building the API
*   **SQLite** - Database for storing data
*   **Swagger/OpenAPI** - API documentation

## Getting Started

### Prerequisites

*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   A tool for running shell commands (like PowerShell, Command Prompt, or Bash)
*   An API client like [Postman](https://www.postman.com/) or [Insomnia](https://insomnia.rest/) to interact with the API.

### Installation & Running the Application

1.  **Clone the repository:**
    ```sh
    git clone https://github.com/AntHavrylov/EventRegistrationSystem.git
    cd EventRegistrationSystem
    ```

2.  **Restore dependencies:**
    ```sh
    dotnet restore
    ```

3.  **Run the application:**
    Navigate to the main project directory and use the `dotnet run` command.
    ```sh
    dotnet run
    ```
    The application will start and listen on the URLs specified in `Properties/launchSettings.json`. By default, these are typically `https://localhost:7110` and `http://localhost:5271`.

4.  **Access the API documentation:**
    Once the application is running, you can access the Swagger UI for API documentation and testing at:
    `http://localhost:5271/swagger`

## API Endpoints

The base URL for all endpoints is `/api`.

### Users

| Method | Endpoint              | Description                  | Authorization |
|--------|-----------------------|------------------------------|---------------|
| `POST` | `/users/register`     | Registers a new user.        | **Required**  |
| `POST` | `/users/login`        | Logs in a user and returns a JWT token. | None          |

### Events

| Method | Endpoint                          | Description                               | Authorization |
|--------|-----------------------------------|-------------------------------------------|---------------|
| `GET`  | `/events`                         | Gets a list of all events.                | None          |
| `GET`  | `/events/{eventId}`               | Gets a single event by its ID.            | None          |
| `POST` | `/events`                         | Creates a new event.                      | **Required**  |
| `POST` | `/events/{eventId}/register`      | Registers the current user for an event.  | None          |
| `GET`  | `/events/{eventId}/registrations` | Gets all registrations for a specific event. | **Required**  |


## Running Tests

To run the unit tests for this project, execute the following command from the root directory:

```sh
dotnet test
```

## Project Structure

*   `EventRegistrationSystem/`: The main ASP.NET Core project.
    *   `Controllers/`: Contains the API controllers that handle incoming HTTP requests.
    *   `Services/`: Contains the business logic for the application.
    *   `DataAccess/`: Handles data access and interaction with the database (SQLite).
    *   `Models/`: Defines the data structures and DTOs (Data Transfer Objects).
    *   `Mapping/`: Contains mapping logic to convert between DTOs and data models.
    *   `Properties/launchSettings.json`: Defines how to launch the application.
*   `EventRegistrationSystemTests.Unit/`: A separate project for unit tests.
