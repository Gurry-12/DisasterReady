using System.Net;

namespace DisasterReady.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public List<string> Errors { get; }
        public HttpStatusCode StatusCode { get; }

        private Result(bool isSuccess, T value, List<string> errors, HttpStatusCode statusCode)
        {
            IsSuccess = isSuccess;
            Value = value ;
            Errors = errors ?? new List<string>();
            StatusCode = statusCode;
        }

        public static Result<T> Success(T value, HttpStatusCode statusCode = HttpStatusCode.OK) =>
            new Result<T>(true, value, [], statusCode);

        public static Result<T> Failure(List<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
            new Result<T>(false, default, errors, statusCode);
    }
}
