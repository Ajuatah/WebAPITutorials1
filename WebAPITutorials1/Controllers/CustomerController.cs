using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPITutorials1.Controllers
{
    public class CustomerController : ApiController
    {
        public string GET()
        {
            return " This is  simple API method Example";
        }
    }
}
