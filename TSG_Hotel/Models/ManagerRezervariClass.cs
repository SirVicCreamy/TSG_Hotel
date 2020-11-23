using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSG_Hotel.Models
{
    public class ManagerRezervariClass
    {
        public int ID_USR { get; set; }
        public int ID_CAM { get; set; }

        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }

        public int Pret_total {get; set;}


    }
}