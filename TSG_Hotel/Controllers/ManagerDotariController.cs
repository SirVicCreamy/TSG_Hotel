using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TSG_Hotel.Models;

namespace TSG_Hotel.Controllers
{
    public class ManagerDotariController : ApiController
    {
        HotelDBEntities hotel = new HotelDBEntities();

        public IHttpActionResult GetManDot() 
        {
            var results = hotel.spManagerDotari(0, 0, "GetManDot").ToList();
            return Ok(results);
        }

    }
}
