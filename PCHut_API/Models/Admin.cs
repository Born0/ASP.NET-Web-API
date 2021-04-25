

namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Admin
    {
        
        public int AdminId { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15,MinimumLength = 11)]
        [MaxLength(15), MinLength(11)]
        public string Phone { get; set; }
    }
}
