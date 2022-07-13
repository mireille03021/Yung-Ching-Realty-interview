using System.ComponentModel.DataAnnotations;

namespace interview.Data
{
    public class Employee
    {
        public Employee()
        {
        }

        [Key]
        public int EmployeeID { get; set; }
        
        public string LastName { get; set; }
        
        public string FirstName { get; set; }

        public string Title { get; set; }

    }
}
