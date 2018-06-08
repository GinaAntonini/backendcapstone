using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BackendCapstone.Models;

namespace BackendCapstone.Services
{
    public class BoardMembersRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MetropolitanProperties"].ConnectionString);
        }

        public bool Create(BoardMembersDto boardmember)
        {
            using (var db = GetConnection())
            {
                db.Open();

                var records = db.Execute(@"INSERT INTO [dbo].[BoardMember]
                                                     ([Name]
                                                     ,[BoardId]
                                                     ,[PhoneNumber]
                                                     ,[EmailAddress])
                                                VALUES
                                                     (@Name
                                                     ,@BoardId
                                                     ,@PhoneNumber
                                                     ,@EmailAddress)", boardmember);
                return records == 1;
            }
        }

    }
}