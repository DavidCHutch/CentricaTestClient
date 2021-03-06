﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.Domain.Models
{
    public class District
    {
        public Guid ID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<Salesman> Salesmen { get; set; }
        public Salesman PrimarySalesman { get; set; }
    }
}
