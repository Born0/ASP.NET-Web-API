
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
            this.Sales_Record = new HashSet<Sales_Record>();
        }

        [Key, Required]
        public int Customer_id { get; set; }
        [Required, StringLength(50, ErrorMessage = "name can't be longer than 50 character")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "provide a proper email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "provide a proper Phone number")]
        [StringLength(15, ErrorMessage = "can't be more than 15 digit", MinimumLength = 11)]
        public string Phone { get; set; }
        [Required, StringLength(50,ErrorMessage ="can't be more than 50 character")]
        public string Address_division { get; set; }
        [Required, StringLength(150, ErrorMessage = "can't be more than 150 character")]
        public string Address_details { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales_Record> Sales_Record { get; set; }
    }
}
