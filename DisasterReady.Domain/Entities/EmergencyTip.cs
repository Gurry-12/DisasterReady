using DisasterReady.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class EmergencyTip
    {
        public int Id { get; set; }
        public DisasterTypeEnum DisasterType { get; set; }
        public string TipTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

}
