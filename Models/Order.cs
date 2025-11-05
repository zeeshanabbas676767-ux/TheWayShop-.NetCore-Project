namespace NewCoreProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [method: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public partial class Order()
    {
        [Key]
        public int Order_Id { get; set; }

        public DateTime? Order_Date { get; set; }

        [StringLength(50)]
        public string? Order_Status { get; set; }

        [StringLength(50)]
        public string? Order_Type { get; set; }

        [Required]
        [StringLength(50)]
        public string? Order_Name { get; set; }

        [StringLength(50)]
        public string? Order_Contact { get; set; }

        [Required]
        [StringLength(100)]
        public string? Order_Address { get; set; }

        [StringLength(50)]
        public string? Order_Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; } = new HashSet<Order_Detail>();
    }
}
