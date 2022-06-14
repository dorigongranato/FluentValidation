namespace FluentValidation.Entity.ErrorModel
{
    public class ErrorDetail
    {
        public string CodigoErro { get; set; }
        public DateTime timestamp { get; set; }
        public List<string> Mensagens { get; set; } = new List<string>();
        //public List<Error> errors { get; set; } = new List<Error>();
    }

    public class Error
    {
        public string message { get; set; }
    }
}

