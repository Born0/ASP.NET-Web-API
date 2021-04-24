namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Sales_Record
    {
        [Key,Required]
        public int Sales_id { get; set; }
        [Required]
        public int Customer_id { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        [Required]
        public int Product_id { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Sub_total { get; set; }
        [Required]
        public int Delivery_status { get; set; }
    
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
