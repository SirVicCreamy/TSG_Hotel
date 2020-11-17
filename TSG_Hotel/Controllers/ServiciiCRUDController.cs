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

        


    }
}
