using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCapstone.Models
{
    public class SendEmailDto
    {
        public int EmergencyReportId { get; set; }
        public DateTime Date { get; set; }
        public int ManagerId { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerName { get; set; }
        public string Caller { get; set; }
        public string CallerPhoneNumber { get; set; }
        public string Address { get; set; }
        public string IncidentDescription { get; set; }
        public string ActionTaken { get; set; }
        public string PropertyName { get; set; }
        public string OnCallManagerName { get; set; }
    }
}