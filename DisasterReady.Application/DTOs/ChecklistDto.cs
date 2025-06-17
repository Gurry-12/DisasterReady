using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.DTOs
{
    public class ChecklistDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ChecklistItemDto> Items { get; set; } = new();
    }

    public class ChecklistItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public PriorityEnum Priority { get; set; }
        public int ChecklistId { get; set; }
    }

    public class CreateChecklistDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
    }

    public class CreateChecklistItemDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PriorityEnum Priority { get; set; } = PriorityEnum.Medium;
        public int ChecklistId { get; set; }
    }
} 