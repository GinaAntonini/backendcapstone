using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackendCapstone.Models;
using BackendCapstone.Services;
using System.Net;
using System.Web.Http;
using System.Net.Http;


namespace BackendCapstone.Controllers
{
    [RoutePrefix("api/emergencyreports")]
    public class EmergencyReportsController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddEmergencyReport(EmergencyReportsDto emergencyreport)
        {
            var repository = new EmergencyReportsRepository();
            var result = repository.Create(emergencyreport);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create emergency report");
        }

        [Route("{id}"), HttpPut]
        public HttpResponseMessage EditEmergencyReport(int Id, EmergencyReportsDto emergencyreport)
        {
            var repository = new EmergencyReportsRepository();
            var result = repository.Edit(Id, emergencyreport);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Report could not be updated");
        }
    }
}