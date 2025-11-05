namespace NewCoreProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore.Migrations;

    [Table("Admin")]
    public partial class User
    {
        [Key]
        public int Admin_Id { get; set; }

        [Required(ErrorMessage = "Required Admin Name.")]
        [StringLength(50)]
        public string? Admin_Name { get; set; }

        [Required(ErrorMessage = "Required Email.")]
        [EmailAddress(ErrorMessage = "Invalid Email Format.")]
        [StringLength(50)] 
        public string? Admin_Email { get; set; }

        [Required(ErrorMessage = "Required Password.")]
        [StringLength(500)]
        public string? Admin_Password { get; set; }

        [Required(ErrorMessage = "Required Contact.")]
        [StringLength(50)]
        public string? Admin_Contact { get; set; }

        [Required(ErrorMessage = "Required Address.")]
        [StringLength(100)]
        public string? Admin_Address { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        [StringLength(500)] 
        public string? ProfileImagePath { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
