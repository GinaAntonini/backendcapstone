using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BackendCapstone.Models;

namespace BackendCapstone.Services
{
    public class PropertiesRepository
    {
        public IEnumerable<PropertiesDto> ListAllProperties()
        {
            using (var db = GetConnection())
            {
                db.Open();

                var getPropertyList = db.Query<PropertiesDto>(@"SELECT Id, Name, TaxId, ManagerId, BoardId, Address, City, PropertyType, NumberOfBuildings, NumberOfUnits, GateAccessCode, FireAlarmPassword, OnSiteContact, WaterShutOffLocation, RoofType, ParkingPolicy, RoofAccessCode, FireAlarmVendorId, InsuranceVendorId, ElevatorVendorId, PlumbingVendorId, ElectricalVendorId, GateVendorId, TowingVendorId, EmergencyRemediationVendorId, ElectricUtilityCompanyId, WaterUtilityCompanyId, AdditionalNotes FROM Property");

                return getPropertyList;

            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MetropolitanProperties"].ConnectionString);
        }

        public bool Create(PropertiesDto property)
        {
            using (var db = GetConnection())
            {
                db.Open();
                    
                var records = db.Execute(@"INSERT INTO [dbo].[Property]
                                                     ([Name]
                                                     ,[TaxId]
                                                     ,[ManagerId]
                                                     ,[BoardId]
                                                     ,[Address]
                                                     ,[City]
                                                     ,[PropertyType]
                                                     ,[NumberOfBuildings]
                                                     ,[NumberOfUnits]
                                                     ,[GateAccessCode]
                                                     ,[FireAlarmPassword]
                                                     ,[OnSiteContact]
                                                     ,[WaterShutOffLocation]
                                                     ,[RoofType]
                                                     ,[ParkingPolicy]
                                                     ,[RoofAccessCode]
                                                     ,[FireAlarmVendorId]
                                                     ,[InsuranceVendorId]
                                                     ,[ElevatorVendorId]
                                                     ,[PlumbingVendorId]
                                                     ,[ElectricalVendorId]
                                                     ,[GateVendorId]
                                                     ,[TowingVendorId]
                                                     ,[EmergencyRemediationVendorId]
                                                     ,[ElectricUtilityCompanyId]
                                                     ,[WaterUtilityCompanyId]
                                                     ,[AdditionalNotes])
                                                VALUES
                                                     (@Name
                                                     ,@TaxId
                                                     ,@ManagerId
                                                     ,@BoardId
                                                     ,@Address
                                                     ,@City
                                                     ,@PropertyType
                                                     ,@NumberOfBuildings
                                                     ,@NumberOfUnits
                                                     ,@GateAccessCode
                                                     ,@FireAlarmPassword
                                                     ,@OnsiteContact
                                                     ,@WaterShutOffLocation
                                                     ,@RoofType,@ParkingPolicy
                                                     ,@RoofAccessCode
                                                     ,@FireAlarmVendorId
                                                     ,@InsuranceVendorId
                                                     ,@ElevatorVendorId
                                                     ,@PlumbingVendorId
                                                     ,@ElectricalVendorId
                                                     ,@GateVendorId
                                                     ,@TowingVendorId
                                                     ,@EmergencyRemediationVendorId
                                                     ,@ElectricUtilityCompanyId
                                                     ,@WaterUtilityCompanyId
                                                     ,@AdditionalNotes)", property);
                return records == 1;
            }
        }
        
    }
}