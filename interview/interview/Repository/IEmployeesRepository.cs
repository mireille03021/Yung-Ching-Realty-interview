using interview.Data;

namespace interview.Repository
{
    //IEmployeeRepository
    public interface IEmployeesRepository
    {
        //新增
        public bool create(Employee employee);

        //刪除
        public bool deleteById(int id);

        //修改
        public bool update(int id,Employee employee);

        //查尋
        public Employee getById(int id);
    }
}
