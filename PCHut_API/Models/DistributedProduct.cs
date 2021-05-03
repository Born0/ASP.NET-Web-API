using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace PCHut_API.Models
{
    public class DistributedProduct
    {

        public int DistributedProductId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int BranchId { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public int Status { get; set; }

        public Branch Branch { get; set; }
        public Product Product { get; set; }

    }
}