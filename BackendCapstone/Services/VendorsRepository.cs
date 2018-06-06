using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BackendCapstone.Models;

namespace BackendCapstone.Services
{
    public class VendorsRepository
    {
        public IEnumerable<VendorsDto> ListAllVendors()
        {
            using (var db = GetConnection())
            {
                db.Open();

                var getVendorList = db.Query<VendorsDto>(@"SELECT Id, Name, PhoneNumber, ContactName, FieldOfWork FROM Vendor");

                return getVendorList;

            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MetropolitanProperties"].ConnectionString);
        }

        public bool Create(VendorsDto vendor)
        {
            using (var db = GetConnection())
            {
                db.Open();

                var records = db.Execute(@"INSERT INTO [dbo].[Vendor]
                                                 ([Name]
                                                 ,[PhoneNumber]
                                                 ,[ContactName]
                                                 ,[FieldOfWork])
                                            VALUES
                                                 (@Name
                                                 ,@PhoneNumber
                                                 ,@ContactName
                                                 ,@FieldOfWork)", vendor);
                return records == 1;
            }
        }

        public bool Edit(int id, VendorsDto vendor)
        {
            using (var db = GetConnection())
            {
                db.Open();

                var edited = db.Execute(@"Update [dbo].[Vendor]
                                                 SET [Name] = @Name
                                                    ,[PhoneNumber] = @PhoneNumber
                                                    ,[ContactName] = @ContactName
                                                    ,[FieldOfWork] = @FieldOfWork
                                                     WHERE [Id] = @Id", new
                                                    {
                                                        vendor.Name,
                                                        vendor.PhoneNumber,
                                                        vendor.ContactName,
                                                        vendor.FieldOfWork,
                                                        id
                                                    });
                return edited == 1; 
            }
        }
    }
}