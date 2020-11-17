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
        

    }
}
