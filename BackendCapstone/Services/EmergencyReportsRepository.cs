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
    }
}