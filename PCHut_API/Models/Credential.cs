
namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Credential
    {
        [Key, Required]
        public int Credential_id { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int User_type { get; set; }
    }
}
