using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simplex.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Lga { get; set; }

        public string State { get; set; }
    }
}