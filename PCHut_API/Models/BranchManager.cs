

namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class BranchManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BranchManager()
        {
            this.Invoices = new HashSet<Invoice>();
            this.Branch = new HashSet<Branch>();
        }

        
        public int BranchManagerId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        
        [MaxLength(15), MinLength(11)]
        public string Phone { get; set; }
        [Required]
        //[ForeignKey("Branch")]
        public int BranchId { get; set; }

        //[Required]
       
        public ICollection< Branch> Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Invoice> Invoices { get; set; }
    }
}
