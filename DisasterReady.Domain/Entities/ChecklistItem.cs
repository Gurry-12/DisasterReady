using DisasterReady.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class ChecklistItem
    {
        public int Id { get; set; }
        public int ChecklistId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public PriorityEnum Priority { get; set; } = PriorityEnum.Medium;
        public ConditionTagEnum ConditionTag { get; set; } = ConditionTagEnum.General;
        public string Notes { get; set; } = string.Empty;

        // Navigation
        public Checklist Checklist { get; set; } = null!;
    }
}
