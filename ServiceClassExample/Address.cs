using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassExample
{
    public class Address
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }
        public string Street { get; set; }

        public Address(string id = null, string country = null, string city = null, string state = null, string street = null, int? zip = null)
        {
            Id = id;
            Country = country;
            City = city;
            State = state;
            Zip = zip;
            Street = street; 
        }
    }
}
