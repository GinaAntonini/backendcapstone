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
    [RoutePrefix("api/boards")]
    public class BoardsController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddNewBoardMember(BoardMembersDto boardmember)
        {
            var repository = new BoardMembersRepository();
            var result = repository.Create(boardmember);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Board could not be added");
        }

        [Route, HttpGet]
        public HttpResponseMessage GetBoardsList()
        {
            var repository = new BoardsRepository();
            var result = repository.ListAllBoards();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage GetSingleBoard(int id)
        {
            var repository = new BoardsRepository();
            var result = repository.GetBoardById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}