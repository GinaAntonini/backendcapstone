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

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage GetSingleVendor(int id)
        {
            var repository = new VendorsRepository();
            var result = repository.GetVendorById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route, HttpPost]
        public HttpResponseMessage AddNewVendor(VendorsDto vendor)
        {
            var repository = new VendorsRepository();
            var result = repository.Create(vendor);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Vendor could not be added");
        }

        [Route("{id}"), HttpPut]
        public HttpResponseMessage EditProperty(int Id, VendorsDto vendor)
        {
            var repository = new VendorsRepository();
            var result = repository.Edit(Id, vendor);

            if(result)
                return Request.CreateResponse(HttpStatusCode.OK);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Vendor could not be updated");
        }
    }
}