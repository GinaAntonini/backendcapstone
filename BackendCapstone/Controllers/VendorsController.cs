using System;
using System.Collections.Generic;
using BackendCapstone.Models;
using BackendCapstone.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendCapstone.Controllers
{
    [RoutePrefix("api/vendors")]
    public class VendorsController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetVendorsList()
        {
            var repository = new VendorsRepository();
            var result = repository.ListAllVendors();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}