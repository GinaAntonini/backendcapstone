using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BackendCapstone.Models;
namespace BackendCapstone.Services
{
    public class BoardsRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MetropolitanProperties"].ConnectionString);
        }

        public bool Create(BoardsDto board)
        {
            using (var db = GetConnection())
            {
                db.Open();

                var records = db.Execute(@"INSERT INTO [dbo].[Board]
                                                     ([Name]
                                                     ,[PropertyId])
                                                VALUES
                                                     (@Name
                                                     ,@PropertyId)", board);
                return records == 1;
            }
        }
    }
}