using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Elevators
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string TypeBuilding { get; set; }
        public string Status { get; set; }
        public DateTime? DateCommissioning { get; set; }
        public DateTime? DateLastInspection { get; set; }
        public string CertificateInspection { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public long? ColumnId { get; set; }

        public virtual Columns Column { get; set; }
    }

}