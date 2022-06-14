namespace FluentValidation.Entity.ErrorModel
{
    public class ErrorDetail
    {
        public string traceId { get; set; }
        public DateTime timestamp { get; set; }
        public List<Error> errors { get; set; } = new List<Error>();
    }

    public class Error
    {
        public string message { get; set; }
    }
}

