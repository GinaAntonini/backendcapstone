using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCapstone.Models
{
    public class BoardMembersDto
    {
        public int BoardMemberId { get; set; }
        public string Name { get; set; }
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}