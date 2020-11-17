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



    }
}
