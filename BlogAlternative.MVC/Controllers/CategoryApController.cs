using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogAlternative.MVC.Controllers
{
    public class CategoryApController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CategoryClass>>(jsonString);
            return View(values);
        }
        public class CategoryClass
        {
            public int ID { get; set; }
            public string CategoryName { get; set; }
        }
    }
}
