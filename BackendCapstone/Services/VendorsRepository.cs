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

                var getVendorList = db.Query<VendorsDto>(@"SELECT   [VendorId] = v.Id
                                                                   ,[VendorName] = v.Name
                                                                   ,[PhoneNumber]
                                                                   ,[ContactName]
                                                                   ,[FieldOfWork]
                                                                   ,[VendorTypeId]
                                                                   ,[VendorTypeName] = vt.[Name]
                                                               FROM [dbo].[Vendor] as v
                                                               left join VendorType as vt on VendorTypeId = vt.Id");

                return getVendorList;

            }
        }

        public VendorsDto GetVendorById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<VendorsDto>(@"SELECT   [VendorId] = v.Id
                                                                          ,[VendorName] = v.Name
                                                                          ,[PhoneNumber]
                                                                          ,[ContactName]
                                                                          ,[FieldOfWork]
                                                                          ,[VendorTypeId]
                                                                          ,[VendorTypeName] = vt.[Name]
                                                                      FROM [dbo].[Vendor] as v
                                                                      left join VendorType as vt on VendorTypeId = vt.Id
                                                                      WHERE v.Id = @id", new { id });


                return result;
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
                                                 SET [VendorName] = @VendorName
                                                    ,[PhoneNumber] = @PhoneNumber
                                                    ,[ContactName] = @ContactName
                                                    ,[FieldOfWork] = @FieldOfWork
                                                     WHERE [Id] = @Id", new
                                                    {
                                                        vendor.VendorName,
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