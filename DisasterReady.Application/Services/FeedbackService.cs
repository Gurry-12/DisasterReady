using DisasterReady.Application.Interfaces;
using DisasterReady.Domain.Entities;
using DisasterReady.Persistence.Interfaces;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
        {
            return await _unitOfWork.Feedbacks.GetAllAsync();
        }

        public async Task<Feedback?> GetFeedbackByIdAsync(int id)
        {
            return await _unitOfWork.Feedbacks.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByUserIdAsync(int userId)
        {
            return await _unitOfWork.Feedbacks.GetAsync(f => f.UserId == userId);
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByTypeAsync(FeedbackTypeEnum type)
        {
            return await _unitOfWork.Feedbacks.GetAsync(f => f.Type == type);
        }

        public async Task<Feedback> CreateFeedbackAsync(Feedback feedback)
        {
            var createdFeedback = await _unitOfWork.Feedbacks.AddAsync(feedback);
            await _unitOfWork.SaveChangesAsync();
            return createdFeedback;
        }

        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            var feedback = await _unitOfWork.Feedbacks.GetByIdAsync(id);
            if (feedback == null) return false;
            _unitOfWork.Feedbacks.Delete(feedback);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Feedback?> UpdateFeedbackAsync(Feedback feedback)
        {
            var existing = await _unitOfWork.Feedbacks.GetByIdAsync(feedback.Id);
            if (existing == null) return null;
            existing.Type = feedback.Type;
            existing.Content = feedback.Content;
            _unitOfWork.Feedbacks.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return existing;
        }

        public async Task<IEnumerable<Feedback>> GetRecentFeedbackAsync(int count = 10)
        {
            var allFeedback = await _unitOfWork.Feedbacks.GetAllAsync();
            return allFeedback
                .OrderByDescending(f => f.SubmittedAt)
                .Take(count)
                .ToList();
        }
    }
} 