using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BackendCapstone.Models;

namespace BackendCapstone.Services
{
    public class VendorTypeRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MetropolitanProperties"].ConnectionString);
        }

        public IEnumerable<VendorTypeDto> ListAllVendorTypes()
        {
            using (var db = GetConnection())
            {
                db.Open();

                var getVendorTypeList = db.Query<VendorTypeDto>(@"SELECT Id, Name FROM VendorType");

                return getVendorTypeList;
            }
        }

        public VendorTypeDto GetVendorTypeById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<VendorTypeDto>(@"SELECT  [Id]
                                                                            ,[Name]
                                                                      FROM [dbo].[VendorType]
                                                                      WHERE Id = @id", new { id });

                return result;
            }
        }
    }
}