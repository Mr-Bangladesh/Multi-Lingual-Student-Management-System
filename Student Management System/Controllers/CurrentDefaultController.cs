using Microsoft.AspNetCore.Mvc;

namespace Student_Management_System.Controllers
{
    public class CurrentDefaultController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
