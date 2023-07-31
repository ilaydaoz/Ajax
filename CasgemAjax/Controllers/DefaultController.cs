using CasgemAjax.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public IActionResult DeleteCustomer(int id)
        {
            var value = context.Costumers.Find(id);
            context.Costumers.Remove(value);
            context.SaveChanges();
            return NoContent();
        }
        public IActionResult GetCustomer(int CostumerID)
        {
            var value = context.Costumers.Find(CostumerID);
           var jsonCustomer = JsonConvert.SerializeObject(value);
            return Json(jsonCustomer);
        }
        public IActionResult UpdateCustomer(Costumer costumer)
        {
           context.Costumers.Update(costumer);
            context.SaveChanges();
            return NoContent();
        }

    }
}
