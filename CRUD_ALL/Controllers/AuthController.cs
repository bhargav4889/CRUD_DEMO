﻿using Microsoft.AspNetCore.Mvc;

namespace CRUD_ALL.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
