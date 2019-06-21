using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventHandlingApp.Models
{
    public class Employee :Person
    {        
       public int EmpId { get; set; }
       public bool Gender { get; set; }

    }
}