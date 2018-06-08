using System;
using System.Collections.Generic;
using BackendCapstone.Models;
using BackendCapstone.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendCapstone.Controllers
{
    [RoutePrefix("api/boardmembers")]
    public class BoardMembersController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddNewBoardMember(BoardMembersDto boardmember)
        {
            var repository = new BoardMembersRepository();
            var result = repository.Create(boardmember);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Board Member could not be added");
        }
    }
}