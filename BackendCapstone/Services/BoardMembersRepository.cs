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

        public IEnumerable<BoardMembersDto> ListAllBoardMembers()
        {
            using (var db = GetConnection())
            {
                db.Open();

                var getBoardMembersList = db.Query<BoardMembersDto>(@"SELECT     [BoardMemberId] = bm.[Id]
                                                                                ,[Name] = bm.[Name]
                                                                                ,[PropertyId]
                                                                                ,[PhoneNumber]
                                                                                ,[EmailAddress]
                                                                                ,[PropertyName] = p.[Name]
                                                                      FROM [dbo].[BoardMember] as bm
                                                                      left join Property as p on PropertyId = p.Id");

                return getBoardMembersList;
            }
        }

        public BoardMembersDto GetBoardMemberById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<BoardMembersDto>(@"SELECT    [BoardMemberId] = bm.Id
                                                                                ,[Name]
                                                                                ,[PropertyId]
                                                                                ,[PhoneNumber]
                                                                                ,[EmailAddress]
                                                                                ,[PropertyName] as p.[Name]
                                                                      FROM [dbo].[BoardMember] as bm
                                                                      left join Property as p on PropertyId = p.Id
                                                                      WHERE Id = @id", new { id });

                return result;
            }
        }

        public bool Create(BoardMembersDto boardmember)
        {
            using (var db = GetConnection())
            {
                db.Open();

                var records = db.Execute(@"INSERT INTO [dbo].[BoardMember]
                                                     ([Name]
                                                     ,[PropertyId]
                                                     ,[PhoneNumber]
                                                     ,[EmailAddress])
                                                VALUES
                                                     (@Name
                                                     ,@PropertyId
                                                     ,@PhoneNumber
                                                     ,@EmailAddress)", boardmember);
                return records == 1;
            }
        }

        public bool Delete(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.Execute(@"DELETE FROM Board WHERE Id = @id", new { id });

                return result == 1;
            }
        }
    }
}