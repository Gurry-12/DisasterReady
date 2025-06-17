namespace DisasterReady.Application.DTOs
{
    public class HouseholdDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public bool HasPets { get; set; }
        public bool HasMedicalNeeds { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class CreateHouseholdDto
    {
        public int UserId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public bool HasPets { get; set; }
        public bool HasMedicalNeeds { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class UpdateHouseholdDto
    {
        public int Adults { get; set; }
        public int Children { get; set; }
        public bool HasPets { get; set; }
        public bool HasMedicalNeeds { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
} 