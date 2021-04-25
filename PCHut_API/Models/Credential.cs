
namespace PCHut_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Credential
    {
        
        public int CredentialId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int UserType { get; set; }
    }
}
