using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSG_Hotel.Models;
using System.Net.Http;

namespace TSG_Hotel.Controllers
{
    public class MVCDotariCRUDController : Controller
    {
        // GET: MVCDotariCRUD
        public ActionResult Dotari()
        {
            IEnumerable<Dotari> dotari_obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/DotariCRUD");

            var consume_api = hc.GetAsync("DotariCRUD");
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_data = read_data.Content.ReadAsAsync<IList<Dotari>>();
                display_data.Wait();
                dotari_obj = display_data.Result;
            }

            return View(dotari_obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Dotari dotare)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/DotariCRUD");

            var insert_dotare = hc.PostAsJsonAsync<Dotari>("DotariCRUD", dotare);
            insert_dotare.Wait();

            var save_data = insert_dotare.Result;
            if (save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Dotari");
            }

            return View("Create");
        }

    }
}