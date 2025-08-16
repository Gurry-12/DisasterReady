namespace DisasterReady.WebAPI.Models
{
    public interface IApiResponse { }

    public class ApiResponse : IApiResponse
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }

        public static ApiResponse Success(object data)
        {
            return new ApiResponse { IsSuccess = true, Data = data };
        }

        public static ApiResponse Failure(List<string> errors) =>
            new ApiResponse { IsSuccess = false, Errors = errors };
    }
}
