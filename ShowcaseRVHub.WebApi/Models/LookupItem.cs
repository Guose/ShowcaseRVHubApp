namespace ShowcaseRVHub.WebApi.Models
{
    public class LookupItem
    {
        public Guid UserId { get; set; }
        public int Id { get; set; }
        public string DisplayMember { get; set; } = string.Empty;
    }

    public class NullLookupItem : LookupItem
    {
        public new Guid? UserId { get { return null; } }
        public new int? Id { get { return null; } }
    }
}