﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TSG_Hotel.Models;

namespace TSG_Hotel.Controllers
{
    public class CamereCRUDController : ApiController
    {
        HotelDBEntities hotel = new HotelDBEntities();
        public IHttpActionResult GetCam()
        {
            var results = hotel.spCRUDCamere(0, 0, 0, "Get").ToList();
            return Ok(results);
        }

        public IHttpActionResult InsertCam(Camere camera)
        {
            var insert_results = hotel.spCRUDCamere(0,camera.Capacitate,camera.Pret, "Insert").ToList();
            return Ok(insert_results);
        }

        public IHttpActionResult GetCamID(int id)
        {
            var details = hotel.spCRUDCamere(id, 0, 0, "GetCamID").Select(x => new CamereClass()
            {
                ID = x.ID,
                Capacitate = (int)x.Capacitate,
                Pret = (int)x.Pret
            }).FirstOrDefault<CamereClass>();

            return Ok(details);
        }

        public IHttpActionResult PutCam(CamereClass camera)
        {
            var update_results = hotel.spCRUDCamere(camera.ID, camera.Capacitate, camera.Pret, "Update").ToList();
            hotel.SaveChanges();
            return Ok(update_results);
        }


        public IHttpActionResult DeleteCam(int id)
        {
            var delete_cam = hotel.spCRUDCamere(id, 0, 0, "Delete").Select(x => new CamereClass()
            {
                ID = x.ID,
                Capacitate = (int)x.Capacitate,
                Pret = (int)x.Pret
            }).FirstOrDefault<CamereClass>();
            hotel.SaveChanges();
            return Ok();
        }

    }
}
