using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace College.Domain.Entities
{
    public class Student : EntityBase
    {
        [Required(ErrorMessage = "Вкажіть групу!")]
        [Display(Name = "Оберіть групу")]
        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        [Required(ErrorMessage = "Заповніть ім'я студента!")]
        [Display(Name = "Ім'я")]
        [MaxLength(20)]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Заповніть прізвище студента!")]
        [Display(Name = "Прізвище")]
        [MaxLength(20)]
        public string? Secondname { get; set; }

        public ICollection<Grade>? Grades { get; set; }
        public ICollection<Absence>? Absences { get; set; }
    }
}
