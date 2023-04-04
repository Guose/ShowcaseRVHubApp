namespace ShowcaseRVHub.Email.Models
{
    public class EmailRequest
    {
        public EmailRequest(string toEmail, string templateId, string templateDataKey, string templateDataValue)
        {
            ToEmail = toEmail;
            TemplateId = templateId;
            TemplateData = new Dictionary<string, string> { { templateDataKey, templateDataValue } };
        }
        public string ToEmail { get; set; }
        public string TemplateId { get; set; }
        public Dictionary<string, string> TemplateData { get; set; }
    }
}
