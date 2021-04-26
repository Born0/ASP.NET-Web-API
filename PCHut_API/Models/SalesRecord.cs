namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class SalesRecord
    {
        
        public int SalesRecordId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double SubTotal { get; set; }
        [Required]
        public int DeliveryStatus { get; set; }
    
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
