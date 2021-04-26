
namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Invoices = new HashSet<Invoice>();
            this.SalesRecord = new HashSet<SalesRecord>();
        }

        
        public int CustomerId { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        
       [MaxLength(15),MinLength(11)]
        public string Phone { get; set; }
        [Required,MaxLength(50)]
        public string AddressDivision { get; set; }
        [Required, MaxLength(150)]
        public string AddressDetails { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Invoice> Invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<SalesRecord> SalesRecord { get; set; }
    }
}
