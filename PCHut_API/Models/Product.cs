namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
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
        [Required, Range(0, int.MaxValue)]
        public int Warranty { get; set; }
        [Required, Range(1.0, Double.MaxValue)]
        public double Price { get; set; }
       
        [Required]
        public int Status { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ProductPic { get; set; }

        public Brand Brand { get; set; }
       
        public Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       
        public ICollection<SalesRecord> SalesRecord { get; set; }
    }
}
