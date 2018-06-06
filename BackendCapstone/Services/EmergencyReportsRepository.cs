using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BackendCapstone.Models;

namespace BackendCapstone.Services
{
    public class EmergencyReportsRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MetropolitanProperties"].ConnectionString);
        }

        public bool Create(EmergencyReportsDto emergencyreport)
        {
            using (var db = GetConnection())
            {
                db.Open();

                var records = db.Execute(@"INSERT INTO [dbo].[EmergencyReport]
                                                     ([Date]
                                                     ,[ManagerId]
                                                     ,[Caller]
                                                     ,[CallerPhoneNumber]
                                                     ,[Address]
                                                     ,[IncidentDescription]
                                                     ,[ActionTaken]
                                                     ,[PropertyId])
                                                VALUES
                                                     (@Date
                                                     ,@ManagerId
                                                     ,@Caller
                                                     ,@CallerPhoneNumber
                                                     ,@Address
                                                     ,@IncidentDescription
                                                     ,@ActionTaken
                                                     ,@PropertyId)", emergencyreport);
                return records == 1;
            }
        }

        public bool Edit(int id, EmergencyReportsDto emergencyreport)
        {
            emergencyreport.Id = id;

            using (var db = GetConnection())
            {
                db.Open();

                var edited = db.Execute(@"Update [dbo].[EmergencyReport]
                                                     SET [Date] = @Date
                                                     ,[ManagerId] = @ManagerId
                                                     ,[Caller] = @Caller
                                                     ,[CallerPhoneNumber] = @CallerPhoneNumber
                                                     ,[Address] = @Address
                                                     ,[IncidentDescription] = @IncidentDescription
                                                     ,[ActionTaken] = @ActionTaken
                                                     ,[PropertyId] = @PropertyId
                                                     WHERE [Id] = @Id", emergencyreport);

                return edited == 1;
            }
        }
    }
}