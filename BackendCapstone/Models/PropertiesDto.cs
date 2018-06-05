using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendCapstone.Models
{
    public class PropertiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AssociationCode { get; set; }
        public string TaxId { get; set; }
        public int ManagerId { get; set; }
        public int BoardId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PropertyType { get; set; }
        public int NumberOfBuildings { get; set; }
        public int NumberOfUnits { get; set; }
        public string GateAccessCode { get; set; }
        public string FireAlarmPassword { get; set; }
        public string OnSiteContact { get; set; }
        public string WaterShutOffLocation { get; set; }
        public string RoofType { get; set; }
        public string ParkingPolicy { get; set; }
        public string RoofAccessCode { get; set; }
        public int FireAlarmVendorId { get; set; }
        public int InsuranceVendorId { get; set; }
        public int ElevatorVendorId { get; set; }
        public int PlumbingVendorId { get; set; }
        public int ElectricalVendorId { get; set; }
        public int GateVendorId { get; set; }
        public int TowingVendorId { get; set; }
        public int EmergencyRemediationVendorId { get; set; }
        public int ElectricUtilityCompanyId { get; set; }
        public int WaterUtilityCompanyId { get; set; }
        public string AdditionalNotes { get; set; }

    }
}