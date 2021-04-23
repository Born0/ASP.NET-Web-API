namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Invoice
    {
        [Key,Required]
        public int Invoice_id { get; set; }
        [Required]
        public int Customer_id { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        [Required]
        public int Branch_manager_id { get; set; }
        [Required]
        public double Added_sub_total { get; set; }
        [Required]
        public int Discount_id { get; set; }
        [Required]
        public double Total_amount { get; set; }
        [Required]
        public int Branch_id { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Branch_Manager Branch_Manager { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
