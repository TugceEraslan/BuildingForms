using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingForms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()   //öreneğin create.cshtml yani view dosyasındaki tüm bilgilerin burada karşılanması gerekir.
                                        //Bu da @model Product ile mümkün. Çünkü Product modelinin içinde Name,Description,Price,IsApproved alanları var.
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }

    }
}
