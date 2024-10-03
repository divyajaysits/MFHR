namespace MF.HR.DTO
{
    public class LogFormat
    {
        public string Request { get; set; }
        public string RequestType { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public int StatusCode { get; set; } = 0;
        public string Severity { get; set; }
        public string Message { get; set; }
        public object Description { get; set; }
        public string AccessType { get; set; }
        public string StackTrace { get; set; } = "";

    }
}
