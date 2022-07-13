using interview.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace interview.Repository
{
    //EmployeeRepository
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly NorthwindContext _northwindContext;

        //Construst
        public EmployeesRepository(NorthwindContext northwindContext)
        {
            this._northwindContext = northwindContext;
        }

        //新增
        public bool create(Employee employee)
        {
            try
            {
                this._northwindContext.Employee.Add(employee);
                this._northwindContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        //刪除
        public bool deleteById(int id)
        {
            var employee = this._northwindContext.Employee.FirstOrDefault(x => x.EmployeeID == id);

            if (employee != null)
            {
                this._northwindContext.Employee.Remove(employee);
                this._northwindContext.SaveChanges();
                return true;
            }

            return false;
        }


        //修改
        public bool update(int id,Employee employee)
        {
            var updatedEmployee = this._northwindContext.Employee.FirstOrDefault(x => x.EmployeeID == id);

            if (updatedEmployee != null)
            {
                updatedEmployee.LastName = employee.LastName;
                updatedEmployee.FirstName = employee.FirstName;
                updatedEmployee.Title = employee.Title;
                this._northwindContext.Employee.Update(updatedEmployee);
                this._northwindContext.SaveChanges();
                return true;
            }

            return false;
        }


        //查詢 By Id
        public Employee getById(int id)
        {
            var employee = this._northwindContext.Employee.FirstOrDefault(x => x.EmployeeID == id);
            return employee;
        }

        //查詢全部
        public List<Employee> get()
        {
            return this._northwindContext.Employee.ToList();
        }
    }
}
