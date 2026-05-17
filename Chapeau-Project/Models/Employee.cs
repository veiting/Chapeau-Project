namespace Chapeau_Project.Models
{
    public enum EmployeeRole { waiter, bar, kitchen, manager }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeNumber { get; set; }
        public string Password { get; set; }
        public EmployeeRole Role { get; set; }
        public bool IsActive { get; set; }

        public Employee() { }

        public Employee(int id, string firstName, string lastName, int employeeNumber, string password, EmployeeRole role)
        {
            EmployeeId = id;
            FirstName = firstName;
            LastName = lastName;
            EmployeeNumber = employeeNumber;
            Password = password;
            Role = role;
            IsActive = true;
        }
    }
}