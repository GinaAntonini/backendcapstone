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

        public IEnumerable<EmergencyReportsDto> GetAllEmergencyReports()
        {
            using (var db = GetConnection())
            {
                db.Open();

                var getEmergencyReports = db.Query<EmergencyReportsDto>(@"SELECT [EmergencyReportId] = er.Id
                                                                                 ,[Date] 
                                                                                 ,[ManagerId] = er.ManagerId
                                                                                 ,[Caller]
                                                                                 ,[CallerPhoneNumber]  
                                                                                 ,[Address] = er.Address
                                                                                 ,[IncidentDescription]
                                                                                 ,[ActionTaken]
                                                                                 ,[PropertyId]
                                                                                 ,[PropertyName] = pi.Name
                                                                                 ,[OnCallManagerName]
                                                                             FROM [dbo].[EmergencyReport] as er
                                                                             left join Property as pi on PropertyId = pi.Id
                                                                             join Manager as m on er.ManagerId = m.Id");

                return getEmergencyReports;

            }
        }

        public EmergencyReportsDto GetEmergencyReportById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<EmergencyReportsDto>(@"SELECT [EmergencyReportId] = er.Id
                                                                                 ,[Date] 
                                                                                 ,[ManagerId] = er.ManagerId
                                                                                 ,[Caller]
                                                                                 ,[CallerPhoneNumber]  
                                                                                 ,[Address] = er.Address
                                                                                 ,[IncidentDescription]
                                                                                 ,[ActionTaken]
                                                                                 ,[PropertyId]
                                                                                 ,[PropertyName] = pi.Name
                                                                                 ,[OnCallManagerName]
                                                                             FROM [dbo].[EmergencyReport] as er
                                                                             left join Property as pi on PropertyId = pi.Id
                                                                             join Manager as m on er.ManagerId = m.Id
                                                                            WHERE er.Id = @Id", new { id });

                return result;
            }
        }

        public SendEmailDto GetEmergencyReportForEmail(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<SendEmailDto>(@"SELECT        [EmergencyReportId] = er.Id
                                                                                 ,[Date] 
                                                                                 ,[ManagerId] = er.ManagerId
                                                                                 ,[ManagerEmail] = m.EmailAddress
                                                                                 ,[ManagerName] = m.Name
                                                                                 ,[Caller]
                                                                                 ,[CallerPhoneNumber]  
                                                                                 ,[Address] = er.Address
                                                                                 ,[IncidentDescription]
                                                                                 ,[ActionTaken]
                                                                                 ,[PropertyId]
                                                                                 ,[PropertyName] = pi.Name
                                                                                 ,[OnCallManagerName]
                                                                             FROM [dbo].[EmergencyReport] as er
                                                                             left join Property as pi on PropertyId = pi.Id
                                                                             join Manager as m on er.ManagerId = m.Id
                                                                            WHERE er.Id = @Id", new { id });

                return result;
            }
        }

        public int Create(EmergencyReportsDto emergencyreport)
        {
            using (var db = GetConnection())
            {
                db.Open();

                var emergencyReportId = db.QuerySingle<int>(@"INSERT INTO [dbo].[EmergencyReport]
                                                     ([Date]
                                                     ,[ManagerId]
                                                     ,[Caller]
                                                     ,[CallerPhoneNumber]
                                                     ,[Address]
                                                     ,[IncidentDescription]
                                                     ,[ActionTaken]
                                                     ,[PropertyId]
                                                     ,[OnCallManagerName])
                                                VALUES
                                                     (@Date
                                                     ,@ManagerId
                                                     ,@Caller
                                                     ,@CallerPhoneNumber
                                                     ,@Address
                                                     ,@IncidentDescription
                                                     ,@ActionTaken
                                                     ,@PropertyId
                                                     ,@OnCallManagerName);
                                                SELECT CAST(SCOPE_IDENTITY() as int)", emergencyreport);
                return emergencyReportId;
            }
        }



        public bool Edit(int id, EmergencyReportsDto emergencyreport)
        {
            emergencyreport.EmergencyReportId = id;

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
                                                     WHERE [EmergencyReportId] = @Id", emergencyreport);

                return edited == 1;
            }
        }
    }
}