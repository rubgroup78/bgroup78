using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class Traveller
    {
        public string ActivityName { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        public string SelctionCountryOfResidence { get; set; }
        public string SelctionAgegroup { get; set; }
        public string SelctionMonth { get; set; }
        public string ActivityPurpose { get; set; }
        public int SelctionNumberOfDays { get; set; }
        public int NumberOfTimes { get; set; }


        public Traveller()
        {

        }
        public List<Traveller> FindActivties()
        {
            DBservices dbs = new DBservices();
            return dbs.FindActivties("ConnectionStringName", this);
        }
    }

}