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

        [Route, HttpGet]
        public HttpResponseMessage GetBoardMembersList()
        {
            var repository = new BoardMembersRepository();
            var result = repository.ListAllBoardMembers();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage GetSingleBoardMember(int id)
        {
            var repository = new BoardMembersRepository();
            var result = repository.GetBoardMemberById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route(""), HttpGet]
        public HttpResponseMessage GetBoardMembersByProperty(string property)
        {
            var repository = new BoardMembersRepository();
            var result = repository.ListAllBoardMembers().Where(bm => bm.PropertyName == property);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{id}/delete"), HttpDelete]
        public HttpResponseMessage DeleteBoardMember(int id)
        {
            var repository = new BoardMembersRepository();
            var result = repository.Delete(id);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK);
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not find board member");
        }
    }
}