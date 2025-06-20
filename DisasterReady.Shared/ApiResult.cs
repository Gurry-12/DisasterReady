namespace DisasterReady.Shared
{
    /// <summary>
    /// Standard API response wrapper for consistent result patterns.
    /// </summary>
    /// <typeparam name="T">Type of the data being returned.</typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// Indicates if the request was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Optional message, typically for errors or additional info.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// The data payload of the response.
        /// </summary>
        public T? Data { get; set; }
    }
} 