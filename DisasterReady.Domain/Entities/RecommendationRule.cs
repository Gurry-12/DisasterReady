using DisasterReady.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class RecommendationRule
    {
        public int Id { get; set; }
        public ConditionTagEnum ConditionTag { get; set; }  // e.g., "pets", "baby", "diabetic"
        public DisasterTypeEnum DisasterType { get; set; } // e.g., "Flood", "Earthquake"
        public string SuggestedItem { get; set; } = null!;
        public string Justification { get; set; } = string.Empty;
    }

}
