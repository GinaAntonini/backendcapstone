using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCapstone.Models
{
    public class EmergencyReportsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ManagerId { get; set; }
        public string Caller { get; set; }
        public string CallerPhoneNumber { get; set; }
        public string Address { get; set; }
        public string IncidentDescription { get; set; }
        public string ActionTaken { get; set; }
        public int PropertyId { get; set; }
    }
}