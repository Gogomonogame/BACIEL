using College.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace College.Models
{
    //DTO потрібен для передачі на клієнт (щоб не передавати доступ до бази даних на пряму)
    public class GroupDTO
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? Speciality { get; set; }
        public int? Course { get; set; }
    }
}
