﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSG_Hotel.Models;
using System.Net.Http;

namespace TSG_Hotel.Controllers
{
    public class MVCCamereCRUDController : Controller
    {
        // GET: MVCCamereCRUD
        public ActionResult Camere()
        {
            IEnumerable<Camere> camere_obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/CamereCRUD");

            var consume_api = hc.GetAsync("CamereCRUD");
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_data = read_data.Content.ReadAsAsync<IList<Camere>>();
                display_data.Wait();
                camere_obj = display_data.Result;
            }

            return View(camere_obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Camere camera)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/CamereCRUD");

            var insert_camera = hc.PostAsJsonAsync<Camere>("CamereCRUD", camera);
            insert_camera.Wait();

            var save_data = insert_camera.Result;
            if(save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Camere");
            }

            return View("Create");
        }

        public ActionResult Details (int id)
        {
            CamereClass camera = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/CamereCRUD");

            var consume_api = hc.GetAsync("CamereCRUD?id=" + id.ToString());
            consume_api.Wait();

            var read_data = consume_api.Result;
            if(read_data.IsSuccessStatusCode)
            {
                var display_details = read_data.Content.ReadAsAsync<CamereClass>();
                display_details.Wait();
                camera = display_details.Result;
            }

            return View(camera);

        }

        public ActionResult Edit(int id)
        {
            CamereClass camera = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/CamereCRUD");

            var consume_api = hc.GetAsync("CamereCRUD?id=" + id.ToString());
            consume_api.Wait();

            var read_data = consume_api.Result;
            if (read_data.IsSuccessStatusCode)
            {
                var display_details = read_data.Content.ReadAsAsync<CamereClass>();
                display_details.Wait();
                camera = display_details.Result;
            }

            return View(camera);
        }

        [HttpPost]
        public ActionResult Edit(CamereClass camera)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/CamereCRUD");

            var update_record = hc.PutAsJsonAsync<CamereClass>("CamereCRUD", camera);
            update_record.Wait();

            var save_data = update_record.Result;
            if (save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Camere");
            }

            return View(camera);
        }


        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44322/api/CamereCRUD");

            var delete_record = hc.DeleteAsync("CamereCRUD/" + id.ToString());
            delete_record.Wait();

            var save_data = delete_record.Result;
            if (save_data.IsSuccessStatusCode)
            {
                return RedirectToAction("Camere");
            }

            return View("Camere");
        }

    }
}