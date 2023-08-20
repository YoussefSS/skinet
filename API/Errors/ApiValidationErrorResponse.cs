namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400) // status code 400, no need for message
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}