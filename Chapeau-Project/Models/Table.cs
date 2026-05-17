namespace Chapeau_Project.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public int? EmployeeId { get; set; }

        public Table() { }

        public Table(int tableId, int tableNumber, int capacity, string status, int? employeeId)
        {
            TableId = tableId;
            TableNumber = tableNumber;
            Capacity = capacity;
            Status = status;
            EmployeeId = employeeId;
        }
    }
}