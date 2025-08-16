using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace College.Domain.Entities
{
    public class Subject : EntityBase
    {
        [Required(ErrorMessage = "Заповніть назву предмета!")]
        [Display(Name = "Назва предмета")]
        [MaxLength(100)]
        public string? SubjectName { get; set; }

        [Required(ErrorMessage = "Заповніть викладача!")]
        [Display(Name = "Викладач")]
        [MaxLength(30)]
        public string? Teacher { get; set; }

        [Required(ErrorMessage = "Вкажіть кількість годин!")]
        [Display(Name = "Кількість годин")]
        public int? Hours { get; set; }

        public ICollection<Grade>? Grades { get; set; }
        public ICollection<Absence>? Absences { get; set; }
    }
}
