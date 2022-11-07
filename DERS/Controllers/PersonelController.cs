using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DERS.Controllers
{
    public class PersonelController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       


    }
}
