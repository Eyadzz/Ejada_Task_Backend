# Employee and Manager Task Management Backend

Welcome to the task management backend, where employees and managers can log in and accomplish tasks within their assigned departments.

## Introduction

This web application is built using the Clean Architecture design pattern along with MediatR, CQRS, and Unit of Work to provide a scalable, maintainable, and loosely coupled architecture. It allows employees and managers to log in, manage employees and tasks, and handle department-related tasks.

## Explanation of Design Patterns and Clean Architecture

### Clean Architecture

Clean Architecture is an architectural pattern that emphasizes separation of concerns and modularity in the design of a software application. The main idea behind Clean Architecture is to create a clear separation between different layers, allowing for flexibility, maintainability, and testability. The layers in Clean Architecture are:

1. **Presentation Layer**: This layer contains the user interface components such as Controllers or API endpoints. It is responsible for handling user interactions and invoking the application's use cases.

2. **Application Layer**: The application layer contains the business logic and use cases of the application. It acts as an intermediary between the presentation and domain layers. The application layer utilizes MediatR for implementing the CQRS pattern.

3. **Domain Layer**: The domain layer represents the core business logic of the application. It contains entities, value objects, and domain services. The domain layer is independent of the infrastructure and application layers, making it reusable and easily testable.

4. **Infrastructure Layer**: The infrastructure layer deals with the implementation of external concerns, such as database access, HTTP services, and external APIs. It also includes the implementation of the Unit of Work pattern for managing database transactions.

Clean Architecture enforces the dependency rule, which states that dependencies should always point inward towards the core of the application. This ensures that the inner layers are not dependent on the outer layers, promoting a more maintainable and loosely coupled codebase.

### MediatR

MediatR is a simple mediator implementation in .NET that aids in decoupling application components. It facilitates the communication between different parts of the application by using the mediator pattern. With MediatR, each application layer, such as the presentation and application layers, can communicate without knowing the concrete implementation of each other.

MediatR helps to implement the CQRS pattern by allowing the separation of commands and queries. Commands represent write operations that modify data, while queries represent read operations that retrieve data. This separation provides better scalability and maintainability by handling reads and writes differently.

### CQRS (Command Query Responsibility Segregation)

CQRS is a pattern that separates the read and write operations in an application. The main idea is to treat commands (changes to the data) and queries (retrieval of data) as separate concerns. By doing so, CQRS provides several benefits:

1. **Scalability**: Since commands and queries have different usage patterns, they can be scaled independently. For example, read-heavy applications can have optimized read models, while write-heavy applications can focus on handling commands efficiently.

2. **Simplified Models**: Command models and query models can be tailored to their specific needs, which leads to more straightforward and focused designs.

3. **Performance**: Separating read and write operations allows for better optimization of data access strategies, leading to improved performance.

### Unit of Work

The Unit of Work pattern is used to manage database transactions and ensure that multiple operations are treated as a single unit. It is especially useful in the context of the infrastructure layer, where data access and persistence occur.

With the Unit of Work pattern, all data operations within a specific transaction are either committed together if all succeed or rolled back in case of any failure. This ensures that the data remains in a consistent state and prevents partial or incomplete updates to the database.

In this project, the Unit of Work pattern is used to encapsulate database operations, ensuring that multiple data operations within a use case are treated as a single transaction, providing data integrity and consistency.

By combining Clean Architecture with MediatR, CQRS, and the Unit of Work pattern, this project achieves a well-organized, scalable, and maintainable codebase that separates concerns and promotes independent development of different application layers. The result is a robust task management system that allows admins, managers, and employees to efficiently handle their tasks and responsibilities.

## Features

### For Admin:

1. **Admin Access**: The system already has an admin account with pre-existing data to access the system directly.

2. **Add Manager**: The admin can add a new manager with basic details like Name, Birthday, Phone Number, and Email Address. The manager will receive an email containing a randomly generated password to log into the system (sending email is optional).

3. **Create Departments**: Admin can create departments within the company, each having a name and a single manager assigned to it.

### For Managers:

1. **Add Employee**: Managers can add new employees to their department with basic data like Name, Birthday, Phone Number, and Email Address. The employee will receive an email containing a randomly generated password to log into the system (sending email is optional).

2. **Manage Employees**: Managers can view, delete, and update the details of employees within their department.

3. **Add Task**: Managers can create new tasks and assign them to existing employees. A task consists of a name, description, and submission date.

4. **Manage Tasks**: Managers can view, delete, and update task details. They can also re-assign tasks to other employees if they are not completed yet.

### For Employees:

1. **Log in**: Employees can log in to the system using their assigned credentials.

2. **View Assigned Tasks**: Employees can examine the tasks assigned to them.

3. **Complete Task**: Employees can mark a task as complete, making it no longer visible to them. Managers can still view completed tasks and have the option to delete them (without editing anything else).

## Getting Started

To run the application, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or your preferred code editor.
3. Ensure you have the required dependencies and packages installed (see the `packages.config` file).
4. Set up the connection strings and configuration in the `appsettings.json` file.

## Usage

1. Start the application and navigate to the login page.

2. Admins can log in using their pre-existing credentials.

3. Managers can log in using their assigned credentials.

4. Employees can log in using their assigned credentials.

5. Once logged in, each user role will have access to their respective features as described above.
