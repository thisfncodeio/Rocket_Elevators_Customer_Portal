using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Customers
    {
        public Customers()
        {
            Addresses = new HashSet<Addresses>();
            Buildings = new HashSet<Buildings>();
            
        }

        public long Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string CompanyName { get; set; }
        public string CpyContactFullName { get; set; }
        public string CpyContactPhone { get; set; }
        public string CpyContactEmail { get; set; }
        public string CpyDescription { get; set; }
        public string TechAuthorityServiceFullName { get; set; }
        public string TechAuthorityServicePhone { get; set; }
        public string TechManagerServiceEmail { get; set; }
        public long? UserId { get; set; }
        public long? AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        // public virtual Users User { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
        
    }
}
