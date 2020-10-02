using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.Domain.Models
{
    public class Store
    {
        public Guid ID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public District District { get; set; }
    }
}
