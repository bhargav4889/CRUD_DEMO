using CRUD_ALL.BAL;
using CRUD_ALL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ALL.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private IConfiguration _configuration;

        private BAL_Employee bal_employee;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            bal_employee = new BAL_Employee(configuration);

        }

        public IActionResult Add_Employee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_Employee(Employee_Model employee)
        {
            bool isInstered = bal_employee.Add_Employee(employee);

            if(isInstered)
            {
                return RedirectToAction("Employees");
            }

            ViewBag.InsertFaliMsg = "Error : Fail to Add Employee";

            return View(employee);
        }

        // POST: Update Employee

        public IActionResult Edit_Employee(int Emp_ID)
        {
            Employee_Model employee = bal_employee.Get_Employee_By_ID(Emp_ID);

            return View(employee);
        }


        [HttpPost]
        public IActionResult Update_Employee(Employee_Model employee)
        {
            bool isUpdated = bal_employee.Update_Employee(employee);

            if (isUpdated)
            {
                return RedirectToAction("Employees");
            }

            ViewBag.UpdateFailMsg = "Error: Failed to Update Employee";
            return View(employee);
        }

        // GET: Delete Employee


        public IActionResult Delete_Employee(int Emp_ID)
        {
            bool isDeleted = bal_employee.Delete_Employee(Emp_ID);

            if (isDeleted)
            {
                ViewBag.DeleteTrueMsg = "Suceess: Delete Employee Suceessfully !!";
                return RedirectToAction("Employees");
            }

            ViewBag.DeleteFailMsg = "Error: Failed to Delete Employee";
            return RedirectToAction("Employees");
        }

        // GET: Show All Employees
        public IActionResult Employees()
        {
            List<Employee_Model> employees = bal_employee.Get_Employees();
            return View(employees);
        }

        // GET: Employee Details By ID
        public IActionResult Employee_Details_View(int Emp_ID)
        {
            Employee_Model employee = bal_employee.Get_Employee_By_ID(Emp_ID);

            if (employee == null)
            {
                return RedirectToAction("Employees");
            }

            return View(employee);
        }
    }
}
