using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Buildings
    {
        public Buildings()
        {
            addresses = new HashSet<Addresses>();
            Batteries = new HashSet<Batteries>();
        }

        public long Id { get; set; }
        public string AdmContactFullName { get; set; }
        public string AdmContactEmail { get; set; }
        public string AdmContactPhone { get; set; }
        public string TechContactFullName { get; set; }
        public string TechContactEmail { get; set; }
        public string TechContactPhone { get; set; }
        public long? CustomerId { get; set; }
        public long? AddressId { get; set; }

        public virtual Addresses address { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<Addresses> addresses { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
    }
}