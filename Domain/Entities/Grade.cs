using System.ComponentModel.DataAnnotations;

namespace College.Domain.Entities
{
    public class Grade : EntityBase
    {
        [Required]
        [Display(Name = "Оберіть студента")]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        [Display(Name = "Оберіть предмет")]
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }

        [Required(ErrorMessage = "Вкажіть дату оцінки!")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Вкажіть оцінку!")]
        [Range(1, 5, ErrorMessage = "Оцінка має бути від 1 до 5")]
        public int? Value { get; set; }
    }
}
