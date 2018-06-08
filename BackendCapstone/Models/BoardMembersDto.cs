using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCapstone.Models
{
    public class BoardMembersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}