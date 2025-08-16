using System.ComponentModel.DataAnnotations;

namespace College.Domain.Entities
{
    public class Group : EntityBase
    {
        public ICollection<Student>? Students { get; set; }

        [Required(ErrorMessage = "Заповніть назву групи!")]
        [Display(Name = "Назва")]
        [MaxLength(10)]
        public string? GroupName { get; set; }

        [Required(ErrorMessage = "Заповніть спеціальність!")]
        [Display(Name = "Спеціальність")]
        [MaxLength(100)]
        public string? Speciality { get; set; }

        [Required(ErrorMessage = "Заповніть курс!")]
        [Display(Name = "Курс")]
        public int? Course { get; set; }
    }
}
