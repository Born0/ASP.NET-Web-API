

namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branch()
        {
            this.Invoices = new HashSet<Invoice>();
            this.Products = new HashSet<Product>();
        }

        [Key, Required]
        public int Branch_id { get; set; }
        [Required, StringLength(50, ErrorMessage = "name can't be longer than 50 character")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(150, ErrorMessage = "Address can't be longer than 50 character")]
        public string Address { get; set; }
    
        public virtual Branch_Manager Branch_Manager { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
