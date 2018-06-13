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
    [RoutePrefix("api/vendortypes")]
    public class VendorTypeController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetVendorTypeList()
        {
            var repository = new VendorTypeRepository();
            var result = repository.ListAllVendorTypes();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage GetSingleVendorType(int id)
        {
            var repository = new VendorTypeRepository();
            var result = repository.GetVendorTypeById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }

}