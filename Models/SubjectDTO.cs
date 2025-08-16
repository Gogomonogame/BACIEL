using College.Domain.Entities;

namespace College.Models
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Teacher { get; set; }
        public int? Hours { get; set; }
    }
}
