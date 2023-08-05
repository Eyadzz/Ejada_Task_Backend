# Employee and Manager Task Management Backend

Welcome to the task management backend, where employees and managers can log in and accomplish tasks within their assigned departments.

## Introduction

This web application is built using the Clean Architecture design pattern along with MediatR, CQRS, and Unit of Work to provide a scalable, maintainable, and loosely coupled architecture. It allows employees and managers to log in, manage employees and tasks, and handle department-related tasks.

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
