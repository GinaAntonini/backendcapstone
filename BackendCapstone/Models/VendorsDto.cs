using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace BackendCapstone.Models
{
    public class VendorsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactName { get; set; }
        public string FieldOfWork { get; set; }
    }
}