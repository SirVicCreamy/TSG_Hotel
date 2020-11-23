using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSG_Hotel.Models;
using System.Net.Http;

namespace TSG_Hotel.Controllers
{
    public class MVCManagerRezervariController : Controller
    {
        // GET: MVCManagerRezervari
        public ActionResult Index()
        {
            IEnumerable<ManagerRezervari> manager_rez = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/ManagerRezervari");

            var consume_api = hc.GetAsync("ManagerRezervari");
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_data = read_data.Content.ReadAsAsync<IList<ManagerRezervari>>();
                display_data.Wait();
                manager_rez = display_data.Result;
            }

            return View(manager_rez);
        }

    }
}