
namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Discount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Discount()
        {
            this.Invoices = new HashSet<Invoice>();
        }
    
        
        public int DiscountId { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,Range(0.0,100.0,ErrorMessage ="must be between 0 to 100")]
        public double Percentage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Invoice> Invoices { get; set; }
    }
}
