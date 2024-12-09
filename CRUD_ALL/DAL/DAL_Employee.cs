using CRUD_ALL.Models;
using System.Data.SqlClient;

namespace CRUD_ALL.DAL
{
    public class DAL_Employee : DAL_Connection
    {
        private readonly IConfiguration _configuration;

        public DAL_Employee(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Add_Employee(Employee_Model employee)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "AUTH_REGISTER_EMPLOYEE";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Emp_Name", employee.Name);

                sqlCommand.Parameters.AddWithValue("@Emp_Email", employee.Email);

                sqlCommand.Parameters.AddWithValue("@Emp_Password", employee.Password);

                int isInserted = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return isInserted > 0;

                
            }
            catch (Exception ex)
            {
                return false;
            }



        }

        public bool Update_Employee(Employee_Model employee)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "AUTH_UPDATE_EMPLOYEE";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Emp_ID", employee.Emp_ID);

                sqlCommand.Parameters.AddWithValue("@Emp_Name", employee.Name);

                sqlCommand.Parameters.AddWithValue("@Emp_Email", employee.Email);

                sqlCommand.Parameters.AddWithValue("@Emp_Password", employee.Password);

                int isUpdate = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return isUpdate > 0;


            }
            catch (Exception ex)
            {
                return false;
            }



        }

        public bool Delete_Employee(int Emp_ID)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "AUTH_DELETE_EMPLOYEE";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Emp_ID", Emp_ID);

                int isDelete = sqlCommand.ExecuteNonQuery();

                return isDelete > 0;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<Employee_Model> Get_All_Employees()
        {
            List<Employee_Model> employees = new List<Employee_Model>();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "AUTH_EMPLOYEES";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    Employee_Model employee = new Employee_Model
                    {
                        Emp_ID = Convert.ToInt32(reader["Emp_ID"].ToString()),
                        Name = reader["Emp_Name"].ToString(),
                        Email = reader["Emp_Email"].ToString(),
                        Password = reader["Emp_Password"].ToString(),

                    };

                    employees.Add(employee);
                }

            }
            catch(Exception ex) {
                Console.WriteLine("Error:" +  ex.Message);
            }

            return employees;
        }

        public Employee_Model Employee_By_ID(int Emp_ID)
        {

            Employee_Model employee = new Employee_Model();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "AUTH_EMPLOYEE_BY_ID";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Emp_ID", Emp_ID);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {


                    employee.Emp_ID = Convert.ToInt32(reader["Emp_ID"]);
                    employee.Name = reader["Emp_Name"].ToString();
                    employee.Email = reader["Emp_Email"].ToString();
                    employee.Password = reader["Emp_Password"].ToString();

                
                   
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return employee;
        }

    }
}
