using CRUD_ALL.DAL;
using CRUD_ALL.Models;

namespace CRUD_ALL.BAL
{
    public class BAL_Employee
    {
        private IConfiguration _configuration;

        private DAL_Employee dal_employee;

        public BAL_Employee(IConfiguration configuration)
        {
            _configuration = configuration;
            dal_employee = new DAL_Employee(configuration);
        }

        public bool Add_Employee(Employee_Model employee)
        {
            bool isSuccessInserted =  dal_employee.Add_Employee(employee);

            return isSuccessInserted;
        }

        public bool Update_Employee(Employee_Model employee)
        {
            bool isSuccessUpdated = dal_employee.Update_Employee(employee);

            return isSuccessUpdated;
        }

        public bool Delete_Employee(int Emp_ID)
        {
            bool isSuccessDelete = dal_employee.Delete_Employee(Emp_ID);

            return isSuccessDelete;
        }

        public List<Employee_Model> Get_Employees()
        {
            List<Employee_Model> employees = dal_employee.Get_All_Employees();

            return employees;
        }

        public Employee_Model Get_Employee_By_ID(int Emp_ID)
        {
            Employee_Model employee = dal_employee.Employee_By_ID(Emp_ID);

            return employee;
        }


    }
}
