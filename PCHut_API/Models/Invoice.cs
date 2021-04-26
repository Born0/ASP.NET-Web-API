namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Invoice
    {
        
        public int InvoiceId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        [Required]
        public int BranchManagerId { get; set; }
        [Required]
        public double AddedSubTotal { get; set; }
        [Required]
        public int DiscountId { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public int BranchId { get; set; }
    
        public Branch Branch { get; set; }
        public BranchManager BranchManager { get; set; }
        public Customer Customer { get; set; }
        public Discount Discount { get; set; }
    }
}
