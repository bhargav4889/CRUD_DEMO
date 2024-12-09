namespace CRUD_ALL.Auth
{
    public class Stored_Details
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Stored_Details(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? Emp_Name()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("Emp_Name");
        }
    }
}
