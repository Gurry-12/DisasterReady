using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllFeedbackAsync();
        Task<Feedback?> GetFeedbackByIdAsync(int id);
        Task<IEnumerable<Feedback>> GetFeedbackByUserIdAsync(int userId);
        Task<IEnumerable<Feedback>> GetFeedbackByTypeAsync(FeedbackTypeEnum type);
        Task<Feedback> CreateFeedbackAsync(Feedback feedback);
        Task<bool> DeleteFeedbackAsync(int id);
        Task<Feedback?> UpdateFeedbackAsync(Feedback feedback);
        Task<IEnumerable<Feedback>> GetRecentFeedbackAsync(int count = 10);
    }
} 