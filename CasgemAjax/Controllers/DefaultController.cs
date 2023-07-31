using CasgemAjax.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CasgemAjax.Controllers
{
    public class DefaultController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
            var jsonCustomer = JsonConvert.SerializeObject(context.Costumers.ToList());
            return Json(jsonCustomer);
        }

        [HttpPost]
        public IActionResult AddCustomer(Costumer costumer)
         {
            context.Costumers.Add(costumer);
            context.SaveChanges();
            var values = JsonConvert.SerializeObject(costumer);
            return Json(values);
        }
    }
}
