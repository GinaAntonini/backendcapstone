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

        [Route, HttpPost]
        public HttpResponseMessage AddNewProperty(PropertiesDto property)
        {
            var repository = new PropertiesRepository();
            var result = repository.Create(property);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Property could not be added");
        }

        [Route("{id}"), HttpPut]
        public HttpResponseMessage EditProperty(int Id, PropertiesDto property)
        {
            var repository = new PropertiesRepository();
            var result = repository.Edit(Id, property);

            if(result)
                return Request.CreateResponse(HttpStatusCode.OK);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Property could not be updated");
        }
    }
}