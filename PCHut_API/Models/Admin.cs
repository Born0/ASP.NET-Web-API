

namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Admin
    {
        [Key,Required]
        public int Admin_id { get; set; }
        [Required,StringLength(50,ErrorMessage ="name can't be longer than 50 character")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Can't be empty")]
        [EmailAddress(ErrorMessage ="provide a proper email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "provide a proper Phone number")]
        [StringLength(15, ErrorMessage = "can't be more than 15 digit", MinimumLength = 11)]
        public string Phone { get; set; }
    }
}
