using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackendCapstone.Models;
using BackendCapstone.Services;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using Example;

namespace BackendCapstone.Controllers
{
    [RoutePrefix("api/emergencyreports")]
    public class EmergencyReportsController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetEmergencyReportsList()
        {
            var repository = new EmergencyReportsRepository();
            var result = repository.GetAllEmergencyReports();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage GetSingleEmergencyReport(int id)
        {
            var repository = new EmergencyReportsRepository();
            var result = repository.GetEmergencyReportById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route(""), HttpGet]
        public HttpResponseMessage GetEmergencyReportsByProperty(string property)
        {
            var repository = new EmergencyReportsRepository();
            var result = repository.GetAllEmergencyReports().Where(er => er.PropertyName == property);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route, HttpPost]
        public HttpResponseMessage AddEmergencyReport(EmergencyReportsDto newEmergencyReport)
        {
            var repository = new EmergencyReportsRepository();
            var id = repository.Create(newEmergencyReport);
            var emergencyReportToSend = repository.GetEmergencyReportForEmail(id);

            var bodyOfEmail =
$@"You are receiving an emergency report below:
Date: {emergencyReportToSend.Date} 
Manager Name: {emergencyReportToSend.ManagerName}
Caller: {emergencyReportToSend.Caller}
Caller Phone Number: {emergencyReportToSend.CallerPhoneNumber}
Property Name: {emergencyReportToSend.PropertyName}
Address: {emergencyReportToSend.Address}
Incident Description: {emergencyReportToSend.IncidentDescription}
Action Taken: {emergencyReportToSend.ActionTaken}
";

            SendgridEmail.Execute(emergencyReportToSend.ManagerEmail, emergencyReportToSend.ManagerName, bodyOfEmail);

      
            return Request.CreateResponse(HttpStatusCode.Created);
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