using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace PatronFactory.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //fabricas
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m, 20);

            //productos
            var localEarn = localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            //calcular ganacias total

            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = 0;
            ViewBag.totalForeign = total + foreignEarn.Earn(total); 

            return View();
        }
    }
}
