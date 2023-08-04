using Domain.DepartmentModule;

namespace Persistence;

public abstract class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
            .HasData(
                new List<Role>
                {
                    new Role
                    {
                        Id = 1,
                        Name = "Admin"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "Employee"
                    },
                    new Role
                    {
                        Id = 3,
                        Name = "Manager"
                    },
                }
            );

        modelBuilder.Entity<User>()
            .HasData(
                new List<User>
                {
                    new User
                    {
                        Id = 1,
                        Name = "Admin",
                        Email = "Admin",
                        PhoneNumber = "012312321123984566",
                        PasswordHash = "$2a$11$dbHhYauUfQyVPuC/UJYbrOAxbZqwRETlK2fi/K9U2EGE6V8bEExN6",
                        RoleId = 1,
                        BirthDate = DateTime.Today
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Employee",
                        Email = "Employee",
                        PhoneNumber = "12301123984290566",
                        PasswordHash = "$2a$11$dbHhYauUfQyVPuC/UJYbrOAxbZqwRETlK2fi/K9U2EGE6V8bEExN6",
                        RoleId = 2,
                        BirthDate = DateTime.Today
                    },
                    new User
                    {
                        Id = 3,
                        Name = "Manager",
                        Email = "Manager",
                        PhoneNumber = "1101123984290566",
                        PasswordHash = "$2a$11$dbHhYauUfQyVPuC/UJYbrOAxbZqwRETlK2fi/K9U2EGE6V8bEExN6",
                        RoleId = 3,
                        BirthDate = DateTime.Today
                    }
                }
            );

        modelBuilder.Entity<Manager>()
            .HasData(
                new Manager
                {
                    Id = 1,
                    UserId = 3,
                    DepartmentId = 1
                }
            );
        
        modelBuilder.Entity<Department>()
            .HasData(
                new Department
                {
                    Id = 1, Name = "IT", ManagerId = 1
                }
            );

        modelBuilder.Entity<Employee>()
            .HasData(
                new Employee
                {
                    Id = 1,
                    UserId = 2,
                    DepartmentId = 1,
                }
            );
        
    }
}