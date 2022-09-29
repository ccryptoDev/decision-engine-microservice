namespace DecisionEngine.Services.Models
{
    public class TransUnionHistory
    {
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; } // User Id ref from user table
    }
}
