using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Columns
    {
        public Columns()
        {
            Elevators = new HashSet<Elevators>();
        }

        public long Id { get; set; }
        public string TypeBuilding { get; set; }
        public int? NumberFloorsServed { get; set; }
        public string Status { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public long? BatteryId { get; set; }

        public virtual Batteries Battery { get; set; }
        public virtual ICollection<Elevators> Elevators { get; set; }
    }
}
