using Microsoft.AspNetCore.Antiforgery;

namespace MyTraining1121AngularDemo.Web.Controllers
{
    public class AntiForgeryController : MyTraining1121AngularDemoControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
