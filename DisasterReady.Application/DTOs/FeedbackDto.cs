using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.DTOs
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public FeedbackTypeEnum Type { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; }
    }

    public class CreateFeedbackDto
    {
        public int UserId { get; set; }
        public FeedbackTypeEnum Type { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    public class UpdateFeedbackDto
    {
        public FeedbackTypeEnum Type { get; set; }
        public string Content { get; set; } = string.Empty;
    }
} 