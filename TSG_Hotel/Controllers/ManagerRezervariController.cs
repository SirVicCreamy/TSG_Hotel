using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TSG_Hotel.Controllers
{
    public class ManagerRezervariController : ApiController
    {
        HotelDBEntities hotel = new HotelDBEntities();
        public IHttpActionResult GetManRez()
        {
            var ci = new DateTime(1, 1, 1);
            var co = new DateTime(1, 1, 1);
            var results = hotel.spManagerRezervari(0,0, ci, co,"Get").ToList();
            return Ok(results);
        }

        


    }
}
