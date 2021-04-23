

namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            this.Products = new HashSet<Product>();
        }

        [Key,Required]
        public int Brand_id { get; set; }
        [Required, StringLength(50, ErrorMessage = "name can't be longer than 50 character")]
        public string Name { get; set; }
        [Required, StringLength(50, ErrorMessage = "vendor name can't be longer than 50 character")]
        public string Vendor_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
