namespace NewCoreProject.Models
{
    using System.Web;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [StringLength(50)]
        public string? Product_Name { get; set; }

        [StringLength(100)]
        public string? Product_Description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Product_PurchasePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Product_SalePrice { get; set; }

        [StringLength(200)]
        public string? Product_Picture { get; set; }
        [NotMapped]
        public IFormFile? Pro_Pic { get; set; }
        [NotMapped]
        public int Prod_Quantity { get; set; } 

        public int? Category_Fid { get; set; }

        public virtual Category? Category { get; set; }
    }
}
