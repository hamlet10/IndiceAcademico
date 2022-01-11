using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IndiceAcademico.Models;

namespace IndiceAcademico.Controllers
{
    public class HomeController : Controller
    {
        public IDataSource dataSource = new ProductDataSource();
        public ViewResult Index()
        {
            return View(dataSource.Products);
        }

    }
}
