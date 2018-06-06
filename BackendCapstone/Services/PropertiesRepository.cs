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

                var getPropertyList = db.Query<PropertiesDto>(@"SELECT Id, Name, AssociationCode, TaxId, ManagerId, BoardId, Address, City, PropertyType, NumberOfBuildings, NumberOfUnits, GateAccessCode, FireAlarmPassword, OnSiteContact, WaterShutOffLocation, RoofType, ParkingPolicy, RoofAccessCode, FireAlarmVendorId, InsuranceVendorId, ElevatorVendorId, PlumbingVendorId, ElectricalVendorId, GateVendorId, TowingVendorId, EmergencyRemediationVendorId, ElectricUtilityCompanyId, WaterUtilityCompanyId, AdditionalNotes FROM Property");

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
                                                     ,[AssociationCode]
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
                                                     ,@AssociationCode
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

        public bool Edit(int id, PropertiesDto property)
        {
            property.Id = id;

            using (var db = GetConnection())
            {
                db.Open();

                var edited = db.Execute(@"Update [dbo].[Property]
                                                     SET [Name] = @Name
                                                     ,[AssociationCode] = @AssociationCode
                                                     ,[TaxId] = @TaxId
                                                     ,[ManagerId] = @ManagerId
                                                     ,[BoardId] = @BoardId
                                                     ,[Address] = @Address
                                                     ,[City] = @City
                                                     ,[PropertyType] = @PropertyType
                                                     ,[NumberOfBuildings] = @NumberOfBuildings
                                                     ,[NumberOfUnits] = @NumberOfUnits
                                                     ,[GateAccessCode] = @GateAccessCode
                                                     ,[FireAlarmPassword] = @FireAlarmPassword
                                                     ,[OnSiteContact] = @OnSiteContact
                                                     ,[WaterShutOffLocation] = @WaterShutOffLocation
                                                     ,[RoofType] = @RoofType
                                                     ,[ParkingPolicy] = @ParkingPolicy
                                                     ,[RoofAccessCode] = @RoofAccessCode
                                                     ,[FireAlarmVendorId] = @FireAlarmVendorId
                                                     ,[InsuranceVendorId] = @InsuranceVendorId
                                                     ,[ElevatorVendorId] = @ElevatorVendorId
                                                     ,[PlumbingVendorId] = @PlumbingVendorId
                                                     ,[ElectricalVendorId] = @ElectricalVendorId
                                                     ,[GateVendorId] = @GateVendorId
                                                     ,[TowingVendorId] = @TowingVendorId
                                                     ,[EmergencyRemediationVendorId] = @EmergencyRemediationVendorId
                                                     ,[ElectricUtilityCompanyId] = @ElectricUtilityCompanyId
                                                     ,[WaterUtilityCompanyId] = @WaterUtilityCompanyId 
                                                     ,[AdditionalNotes] = @AdditionalNotes
                                                     WHERE [Id] = @Id", property);

                return edited == 1;
            }
        } 
    }
}