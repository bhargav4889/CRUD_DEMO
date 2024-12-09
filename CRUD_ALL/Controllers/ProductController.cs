using Microsoft.AspNetCore.Mvc;

namespace CRUD_ALL.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
