using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.DTOs
{
    public class AlertDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Message { get; set; } = null!;
        public SeverityLevelEnum SeverityLevel { get; set; }
        public RegionEnum Region { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Source { get; set; } = string.Empty;
        public int DisasterTypeId { get; set; }
        public string DisasterTypeName { get; set; } = string.Empty;
    }

    public class CreateAlertDto
    {
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Message { get; set; } = null!;
        public SeverityLevelEnum SeverityLevel { get; set; }
        public RegionEnum Region { get; set; }
        public int DisasterTypeId { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Source { get; set; } = "System";
    }

    public class UpdateAlertDto
    {
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Message { get; set; } = null!;
        public SeverityLevelEnum SeverityLevel { get; set; }
        public RegionEnum Region { get; set; }
        public bool IsActive { get; set; }
        public int DisasterTypeId { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
} 