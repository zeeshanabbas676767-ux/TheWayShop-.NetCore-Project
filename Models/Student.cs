using System.ComponentModel.DataAnnotations;

namespace NewCoreProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string? Name { get; set; }

        public int Age { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;
    }
}
