using System.ComponentModel.DataAnnotations;

namespace College.Domain.Entities
{
    public class Timetable : EntityBase
    {
        [Display(Name = "Розклад")]
        [MaxLength(300)]
        public string? Schedule { get; set; }

        [Display(Name ="Заміни")]
        [MaxLength(300)]
        public string? Changes { get; set; }
    }
}
