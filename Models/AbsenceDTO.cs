using College.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace College.Models
{
    public class AbsenceDTO
    {
        public int Id { get; set; }
        public string? StudentFirstname { get; set; }
        public string? StudentSecondname { get; set; }
        public string? SubjectName { get; set; }
        public DateTime? Date { get; set; }
        public bool IsClosed { get; set; }
    }
}
