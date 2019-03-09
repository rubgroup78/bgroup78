using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class TravellerController : ApiController
    {
     
        public IEnumerable<Traveller> Get(Traveller T)
        {
            List<Traveller> Activities = T.FindActivties();
            return Activities;
        }
    }
}
