using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.DTOs
{
    public class EmergencyTipDto
    {
        public int Id { get; set; }
        public string TipTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DisasterTypeEnum DisasterType { get; set; }
    }

    public class CreateEmergencyTipDto
    {
        public string TipTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DisasterTypeEnum DisasterType { get; set; }
    }

    public class UpdateEmergencyTipDto
    {
        public string TipTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DisasterTypeEnum DisasterType { get; set; }
    }
} 