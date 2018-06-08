using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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