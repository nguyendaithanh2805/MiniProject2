namespace Api.ApiResponses
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public string? message { get; set; }
        public T? Data { get; set; }

        public ApiResponse(bool status, string? message, T? data)
        {
            Status = status;
            this.message = message;
            Data = data;
        }
    }
}
