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
        public string ItemName { get; set; } = null!;
        public ConditionTagEnum ConditionTag { get; set; }  // e.g., pets, infants, diabetic
        public bool IsChecked { get; set; } = false;
        public string Notes { get; set; } = string.Empty;

        // Navigation
        public Checklist Checklist { get; set; } = null!;
    }

}
