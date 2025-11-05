namespace NewCoreProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderDetail_Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_Fid { get; set; }

        public int? Product_Fid { get; set; }

        public decimal? Sale_Price { get; set; }

        public decimal? Purchase_Price { get; set; }

        public int? Quantity { get; set; }

        public virtual Order? Order { get; set; }
    }
}
