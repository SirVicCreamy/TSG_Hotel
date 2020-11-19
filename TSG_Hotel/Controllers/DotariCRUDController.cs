using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TSG_Hotel.Models;

namespace TSG_Hotel.Controllers
{
    public class DotariCRUDController : ApiController
    {
        HotelDBEntities hotel = new HotelDBEntities();
        public IHttpActionResult GetDot()
        {
            var results = hotel.spCRUDDotari(0,"", 0, "Get").ToList();
            return Ok(results);
        }

        public IHttpActionResult InsertDot(Dotari dotare)
        {
            var insert_results = hotel.spCRUDDotari(0, dotare.Nume, dotare.Pret, "Insert").ToList();
            return Ok(insert_results);
        }

        public IHttpActionResult GetDotID(int id)
        {
            var details = hotel.spCRUDDotari(id, "", 0, "GetDotID").Select(x => new DotariClass()
            {
                ID = x.ID,
                Nume = x.Nume,
                Pret = (int)x.Pret
            }).FirstOrDefault<DotariClass>();

            return Ok(details);
        }

        public IHttpActionResult PutDot(DotariClass dotare)
        {
            var update_results = hotel.spCRUDDotari(dotare.ID,dotare.Nume,dotare.Pret,"Update").ToList();
            hotel.SaveChanges();
            return Ok(update_results);
        }


        public IHttpActionResult DeleteDot(int id)
        {
            var delete_dot = hotel.spCRUDDotari(id, "", 0, "Delete").Select(x => new DotariClass()
            {
                ID = x.ID,
                Nume=x.Nume,
                Pret = (int)x.Pret
            }).FirstOrDefault<DotariClass>();
            hotel.SaveChanges();
            return Ok();
        }

    }
}
