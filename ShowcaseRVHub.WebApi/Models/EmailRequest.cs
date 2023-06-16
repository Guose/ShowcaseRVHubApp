namespace ShowcaseRVHub.WebApi.Models
{
    public class EmailRequest
    {
        public EmailRequest(string toEmail, string templateId, string templateDataKey, string templateDataValue)
        {
            ToEmail = toEmail;
            TemplateId = templateId;
            TemplateData = new Dictionary<string, string> { { templateDataKey, templateDataValue } };
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ToEmail { get; set; }
        public string TemplateId { get; set; }
        public string Email { get; set; } = string.Empty;
        public Dictionary<string, string> TemplateData { get; set; }
    }
}
