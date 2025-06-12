using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class Household
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public bool HasPets { get; set; }
        public bool HasMedicalNeeds { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Navigation
        public User User { get; set; } = null!;
    }

}
