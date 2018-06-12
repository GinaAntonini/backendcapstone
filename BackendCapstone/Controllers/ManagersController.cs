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
    [RoutePrefix("api/managers")]
    public class ManagersController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetManagersList()
        {
            var repository = new ManagersRepository();
            var result = repository.ListAllManagers();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage GetSingleManager(int id)
        {
            var repository = new ManagersRepository();
            var result = repository.GetManagerById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}