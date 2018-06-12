using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BackendCapstone.Models;

namespace BackendCapstone.Services
{
    public class ManagersRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MetropolitanProperties"].ConnectionString);
        }

        public IEnumerable<ManagersDto> ListAllManagers()
        {
            using (var db = GetConnection())
            {
                db.Open();

                var getManagerList = db.Query<ManagersDto>(@"SELECT Id, Name, PhoneNumber, EmailAddress FROM Manager");

                return getManagerList;
            }
        }

        public ManagersDto GetManagerById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<ManagersDto>(@"SELECT  [Id]
                                                                          ,[Name]
                                                                          ,[PhoneNumber]
                                                                          ,[EmailAddress]
                                                                      FROM [dbo].[Manager]
                                                                      WHERE Id = @id", new { id });

                return result;
            }
        }
    }
}