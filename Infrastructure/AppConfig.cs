namespace College.Infrastructure
{
    public class AppConfig
    {
        public Database Database { get; set; } = new Database();
        public TinyMCE TinyMCE { get; set; } = new TinyMCE();
        public Organization Organization { get; set; } = new Organization();
    }
    public class Database
    {
        public string? ConnectionString { get; set; }
    }
    public class TinyMCE
    {
        public string? APIKey { get; set; }
    }
    public class Organization
    {
        public string? OrganizationName { get; set; }
        public string? OrganizationAuthor { get; set; }
    }
}
