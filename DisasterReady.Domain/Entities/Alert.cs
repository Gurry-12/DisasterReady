using DisasterReady.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class Alert
    {
        public int Id { get; set; }
        public string Location { get; set; } = null!;
        public string Message { get; set; } = null!;
        public SeverityLevelEnum Severity { get; set; }  // Low/Moderate/High
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Source { get; set; } = "System";
    }

}
