using DisasterReady.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class DisasterType
    {
        public int Id { get; set; }
        public DisasterTypeEnum Name { get; set; } 
        public string Description { get; set; } = string.Empty;
        public RegionEnum Region { get; set; }  // Default

        // Navigation
        public ICollection<Checklist> Checklists { get; set; } = new List<Checklist>();
        public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
    }

}
