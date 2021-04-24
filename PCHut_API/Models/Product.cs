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
            this.Sales_Record = new HashSet<Sales_Record>();
        }

        [Key,Required]
        public int Product_id { get; set; }
        [Required, StringLength(150, ErrorMessage = "name can't be longer than 150 character")]
        public string Product_name { get; set; }
        [Required]
        public int Brand_id { get; set; }
        [Required]
        public int Category_id { get; set; }
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
        public int Branch_id { get; set; }
    
        [JsonIgnore]
        public virtual Branch Branch { get; set; }
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Sales_Record> Sales_Record { get; set; }
    }
}
