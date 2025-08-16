using System.ComponentModel.DataAnnotations;

namespace College.Domain.Entities
{
    public class Absence : EntityBase
    {
        [Required]
        [Display(Name = "Оберіть студента")]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        [Display(Name = "Оберіть предмет")]
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }

        [Required(ErrorMessage = "Вкажіть дату пропуску!")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = "Закритий")]
        public bool IsClosed { get; set; }
    }
}
