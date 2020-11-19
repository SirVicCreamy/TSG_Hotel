using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSG_Hotel.Models;
using System.Net.Http;

namespace TSG_Hotel.Controllers
{
    public class MVCServiciiCRUDController : Controller
    {
        // GET: MVCServiciiCRUD
        public ActionResult Servicii()
        {
            IEnumerable<Servicii> servicii_obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/ServiciiCRUD");

            var consume_api = hc.GetAsync("ServiciiCRUD");
            consume_api.Wait();

            var read_data = consume_api.Result;
            if(read_data.IsSuccessStatusCode)
            {
                var display_data = read_data.Content.ReadAsAsync<IList<Servicii>>();
                display_data.Wait();
                servicii_obj = display_data.Result;
            }

            return View(servicii_obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Servicii serviciu)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/ServiciiCRUD");

            var insert_serviciu = hc.PostAsJsonAsync<Servicii>("ServiciiCRUD", serviciu);
            insert_serviciu.Wait();

            var save_data = insert_serviciu.Result;
            if (save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Servicii");
            }

            return View("Create");
        }

        public ActionResult Details(int id)
        {
            ServiciiClass serviciu = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/ServiciiCRUD");

            var consume_api = hc.GetAsync("ServiciiCRUD?id=" + id.ToString());
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_details = read_data.Content.ReadAsAsync<ServiciiClass>();
                display_details.Wait();
                serviciu = display_details.Result;
            }

            return View(serviciu);

        }

        public ActionResult Edit(int id)
        {
            ServiciiClass serviciu = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/ServiciiCRUD");

            var consume_api = hc.GetAsync("ServiciiCRUD?id=" + id.ToString());
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_details = read_data.Content.ReadAsAsync<ServiciiClass>();
                display_details.Wait();
                serviciu = display_details.Result;
            }

            return View(serviciu);

        }

        [HttpPost]
        public ActionResult Edit(ServiciiClass serviciu)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/ServiciiCRUD");

            var update_record = hc.PutAsJsonAsync<ServiciiClass>("ServiciiCRUD", serviciu);
            update_record.Wait();

            var save_data = update_record.Result;
            if (save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Servicii");
            }

            return View(serviciu);
        }


        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/ServiciiCRUD");

            var delete_record = hc.DeleteAsync("ServiciiCRUD/" + id.ToString());
            delete_record.Wait();

            var save_data = delete_record.Result;
            if (save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Servicii");
            }

            return View("Servicii");
        }


    }
}