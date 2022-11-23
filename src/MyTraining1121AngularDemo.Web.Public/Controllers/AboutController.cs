using Microsoft.AspNetCore.Mvc;
using MyTraining1121AngularDemo.Web.Controllers;

namespace MyTraining1121AngularDemo.Web.Public.Controllers
{
    public class AboutController : MyTraining1121AngularDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}