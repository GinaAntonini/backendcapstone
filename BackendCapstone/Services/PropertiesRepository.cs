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

                var getPropertyList = db.Query<PropertiesDto>(@"SELECT [PropertyId] = p.Id
                                                                          ,[PropertyName] = p.[Name]
                                                                          ,[AssociationCode]
                                                                          ,[TaxId]
                                                                          ,[ManagerId]  
                                                                          ,[ManagerName] = m.[Name]
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
                                                                          ,[FireAlarmVendorName] = vfa.[Name]
                                                                          ,[InsuranceVendorName] = vi.[Name]
                                                                          ,[ElevatorVendorName] = ve.[Name]
                                                                          ,[PlumbingVendorName] = vp.[Name]
                                                                          ,[ElectricalVendorName] = vel.[Name]
                                                                          ,[GateVendorName] = vg.[Name]
                                                                          ,[TowingVendorName] = vt.[Name]
                                                                          ,[EmergencyRemediationVendorName] = ver.[Name]
                                                                          ,[ElectricUtilityCompanyName] = veu.[Name]
                                                                          ,[WaterUtilityCompanyName] = vwu.[Name]
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
                                                                          ,[AdditionalNotes]
                                                                      FROM [dbo].[Property] as p
																	  join Manager as m on p.ManagerId = m.Id
																	  left join Vendor as vfa on p.FireAlarmVendorId = vfa.Id
																	  left join Vendor as vi on p.InsuranceVendorId = vi.Id
                                                                      left join Vendor as ve on p.ElevatorVendorId = ve.Id
																	  left join Vendor as vp on p.PlumbingVendorId = vp.Id
																	  left join Vendor as vel on p.ElectricalVendorId = vel.Id
																	  left join Vendor as vg on p.GateVendorId = vg.Id
																	  left join Vendor as vt on p.TowingVendorId = vt.Id
																	  left join Vendor as ver on p.EmergencyRemediationVendorId = ver.Id
																	  left join Vendor as veu on p.ElectricUtilityCompanyId = veu.Id
																	  left join Vendor as vwu on p.WaterUtilityCompanyId = vwu.Id");

                return getPropertyList;

            }
        }

        public PropertiesDto GetPropertyById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<PropertiesDto>(@"SELECT [PropertyId] = p.Id
                                                                          ,[PropertyName] = p.[Name]
                                                                          ,[AssociationCode]
                                                                          ,[TaxId]
                                                                          ,[ManagerId]  
                                                                          ,[ManagerName] = m.[Name]
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
                                                                          ,[FireAlarmVendorName] = vfa.[Name]
                                                                          ,[InsuranceVendorName] = vi.[Name]
                                                                          ,[ElevatorVendorName] = ve.[Name]
                                                                          ,[PlumbingVendorName] = vp.[Name]
                                                                          ,[ElectricalVendorName] = vel.[Name]
                                                                          ,[GateVendorName] = vg.[Name]
                                                                          ,[TowingVendorName] = vt.[Name]
                                                                          ,[EmergencyRemediationVendorName] = ver.[Name]
                                                                          ,[ElectricUtilityCompanyName] = veu.[Name]
                                                                          ,[WaterUtilityCompanyName] = vwu.[Name]
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
                                                                          ,[AdditionalNotes]
                                                                      FROM [dbo].[Property] as p
																	  join Manager as m on p.ManagerId = m.Id
																	  left join Vendor as vfa on p.FireAlarmVendorId = vfa.Id
																	  left join Vendor as vi on p.InsuranceVendorId = vi.Id
                                                                      left join Vendor as ve on p.ElevatorVendorId = ve.Id
																	  left join Vendor as vp on p.PlumbingVendorId = vp.Id
																	  left join Vendor as vel on p.ElectricalVendorId = vel.Id
																	  left join Vendor as vg on p.GateVendorId = vg.Id
																	  left join Vendor as vt on p.TowingVendorId = vt.Id
																	  left join Vendor as ver on p.EmergencyRemediationVendorId = ver.Id
																	  left join Vendor as veu on p.ElectricUtilityCompanyId = veu.Id
																	  left join Vendor as vwu on p.WaterUtilityCompanyId = vwu.Id
                                                                      WHERE p.Id = @id", new { id });

                return result;
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
                                                     ,[AdditionalNotes]
                                                     ,[LandscapingVendorId])
                                                VALUES
                                                     (@Name
                                                     ,@AssociationCode
                                                     ,@TaxId
                                                     ,@ManagerId
                                                     ,@Address
                                                     ,@City
                                                     ,@PropertyType
                                                     ,@NumberOfBuildings
                                                     ,@NumberOfUnits
                                                     ,@GateAccessCode
                                                     ,@FireAlarmPassword
                                                     ,@OnSiteContact
                                                     ,@WaterShutOffLocation
                                                     ,@RoofType
                                                     ,@ParkingPolicy
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
                                                     ,@AdditionalNotes
                                                     ,@LandscapingVendorId)", property);
                return records == 1;
            }
        }

        public bool Edit(int id, PropertiesDto property)
        {
            //property.PropertyId = id;

            using (var db = GetConnection())
            {
                db.Open();

                var edited = db.Execute(@"Update [dbo].[Property]
                                                     SET [Name] = @PropertyName
                                                     ,[AssociationCode] = @AssociationCode
                                                     ,[TaxId] = @TaxId
                                                     ,[ManagerId] = @ManagerId
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
                                                     ,[LandscapingVendorId] = @LandscapingVendorId
                                                     WHERE [Id] = @Id", new
                                                        {
                                                            property.PropertyName,
                                                            property.AssociationCode,
                                                            property.TaxId,
                                                            property.ManagerId,
                                                            property.Address,
                                                            property.City,
                                                            property.PropertyType,
                                                            property.NumberOfBuildings,
                                                            property.NumberOfUnits,
                                                            property.GateAccessCode,
                                                            property.FireAlarmPassword,
                                                            property.OnSiteContact,
                                                            property.WaterShutOffLocation,
                                                            property.RoofType,
                                                            property.ParkingPolicy,
                                                            property.RoofAccessCode,
                                                            property.FireAlarmVendorId,
                                                            property.InsuranceVendorId,
                                                            property.ElevatorVendorId,
                                                            property.PlumbingVendorId,
                                                            property.ElectricalVendorId,
                                                            property.GateVendorId,
                                                            property.TowingVendorId,
                                                            property.EmergencyRemediationVendorId,
                                                            property.ElectricUtilityCompanyId,
                                                            property.WaterUtilityCompanyId,
                                                            property.AdditionalNotes,
                                                            property.LandscapingVendorId,
                                                            id
                                                        });

                return edited == 1;
            }
        } 
    }
}