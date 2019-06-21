using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventHandlingApp.Models
{
    public class ReceptionPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
    }
}