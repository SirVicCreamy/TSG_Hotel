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

        public ActionResult Details(int id)
        {
            DotariClass dotare = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/DotariCRUD");

            var consume_api = hc.GetAsync("DotariCRUD?id=" + id.ToString());
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_details = read_data.Content.ReadAsAsync<DotariClass>();
                display_details.Wait();
                dotare = display_details.Result;
            }

            return View(dotare);

        }

        public ActionResult Edit(int id)
        {
            DotariClass dotare = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/DotariCRUD");

            var consume_api = hc.GetAsync("DotariCRUD?id=" + id.ToString());
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_details = read_data.Content.ReadAsAsync<DotariClass>();
                display_details.Wait();
                dotare = display_details.Result;
            }

            return View(dotare);
        }

        [HttpPost]
        public ActionResult Edit(DotariClass dotare)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/DotariCRUD");

            var update_record = hc.PutAsJsonAsync<DotariClass>("DotariCRUD", dotare);
            update_record.Wait();

            var save_data = update_record.Result;
            if (save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Dotari");
            }

            return View(dotare);
        }


        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/DotariCRUD");

            var delete_record = hc.DeleteAsync("DotariCRUD/" + id.ToString());
            delete_record.Wait();

            var save_data = delete_record.Result;
            if (save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Dotari");
            }

            return View("Dotari");
        }


    }
}