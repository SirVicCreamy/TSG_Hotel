using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TSG_Hotel.Models;

namespace TSG_Hotel.Controllers
{
    public class ServiciiCRUDController : ApiController
    {
        HotelDBEntities hotel = new HotelDBEntities();
        public IHttpActionResult GetSer()
        {
            var results = hotel.spCRUDServicii(0, "", 0, "Get").ToList();
            return Ok(results);
        }

        public IHttpActionResult InsertSer(Servicii serviciu)
        {
            var insert_results = hotel.spCRUDServicii(0,serviciu.Nume, serviciu.Pret, "Insert").ToList();
            return Ok(insert_results);
        }

        public IHttpActionResult GetSerID(int id)
        {
            var details = hotel.spCRUDServicii(id, "", 0, "GetSerID").Select(x => new ServiciiClass()
            {
                ID = x.ID,
                Nume = x.Nume,
                Pret = (int)x.Pret
            }).FirstOrDefault<ServiciiClass>();

            return Ok(details);
        }

    }
}
