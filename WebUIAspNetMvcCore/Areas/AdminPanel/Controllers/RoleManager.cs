﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.Admin.Controllers
{
    [Area("AdminPanel")]
    public class RoleManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
