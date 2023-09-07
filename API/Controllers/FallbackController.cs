using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // This class is needed for Angular
    // We derive from Controller, Not BaseApiController or ControllerBase as Controller has 'view support'
    // This means this controller will return a view, which is an index.html which Angular will generate for us
    public class FallbackController : Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/HTML");
        }
    }
}