using Microsoft.AspNetCore.Mvc;

namespace Tugas_2_Kelompok_4.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
