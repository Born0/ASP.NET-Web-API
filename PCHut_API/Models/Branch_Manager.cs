

namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Branch_Manager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branch_Manager()
        {
            this.Invoices = new HashSet<Invoice>();
        }

        [Key,Required]
        public int Branch_manager_id { get; set; }
        [Required, StringLength(50, ErrorMessage = "name can't be longer than 50 character")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        [EmailAddress(ErrorMessage = "provide a proper email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "provide a proper Phone number")]
        [StringLength(15,ErrorMessage ="can't be more than 15 digit",MinimumLength =11)]
        public string Phone { get; set; }
        
        
        //public int Branch_id { get; }

        //[ForeignKey("Branch_id")]
        //public Branch Branch { get; set; }
        [Required]
        public virtual Branch Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
