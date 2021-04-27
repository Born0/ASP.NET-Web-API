using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCHut_API.View_Model
{
    public class TopBranchManagerModel
    {
        public int BranchManagerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public double SumAmount { get; set; } //Sum Amount

        public int BranchId { get; set; }
    }
}