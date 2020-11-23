using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSG_Hotel.Models;
using System.Net.Http;

namespace TSG_Hotel.Controllers
{
    public class MVCManagerDotariController : Controller
    {
        // GET: MVCManagerDotari
        public ActionResult Index()
        {
            IEnumerable<ManagerDotariClass> mandot_obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/CamereCRUD");

            var consume_api = hc.GetAsync("CamereCRUD");
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_data = read_data.Content.ReadAsAsync<IList<ManagerDotariClass>>();
                display_data.Wait();
                mandot_obj = display_data.Result;
            }

            return View(mandot_obj);
        }
    }
}