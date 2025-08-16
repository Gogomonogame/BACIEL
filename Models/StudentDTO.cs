using College.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace College.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? Firstname { get; set; }
        public string? Secondname { get; set; }
    }
}
