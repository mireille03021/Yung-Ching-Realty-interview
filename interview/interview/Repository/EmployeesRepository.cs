using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interview.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public EmployeesRepository()
        {
        }

        public string getEmployee()
        {
            return "員工資訊";
        } 
    }
}
