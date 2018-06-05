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
    [RoutePrefix("api/properties")]
    public class PropertiesController : ApiController
    {
       [Route, HttpGet]
       public HttpResponseMessage GetPropertiesList()
        {
            var repository = new PropertiesRepository();
            var result = repository.ListAllProperties();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}