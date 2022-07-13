using interview.Data;
using System.Collections.Generic;

namespace interview.Repository
{
    //IEmployeeRepository
    public interface IEmployeesRepository
    {
        //新增
        public bool create(Employee employee);

        //刪除 By Id
        public bool deleteById(int id);

        //修改
        public bool update(int id,Employee employee);

        //查尋 By Id
        public Employee getById(int id);

        //查詢
        public List<Employee> get();

    }
}
