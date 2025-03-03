// The controller handles the routes I establish
// for example /test
using Microsoft.AspNetCore.Mvc;

namespace MyDashboardApp.AddControllersWithViews
{
    public class TestController : Controller
    {
        //Map the /test url to this action using attribure routing
        [HttpGet("/test")]
        public IActionResult Index()
        {
            //Return the view "test"
            return View("Test");
        }
    }
}