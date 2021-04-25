namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.SalesRecord = new HashSet<SalesRecord>();
        }

      
        public int ProductId { get; set; }
        [Required,MaxLength(150)]
        public string ProductName { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string Special { get; set; }
        [Required]
        public int Warranty { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Status { get; set; }
        
        public string Image { get; set; }
        [Required]
        public int BranchId { get; set; }
    
        //[JsonIgnore]
        public Branch Branch { get; set; }
        //[JsonIgnore]
        public Brand Brand { get; set; }
        //[JsonIgnore]
        public Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //[JsonIgnore]
        public ICollection<SalesRecord> SalesRecord { get; set; }
    }
}
