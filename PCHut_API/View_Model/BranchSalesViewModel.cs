using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCHut_API.View_Model
{
    public class BranchSalesViewModel
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public double TotalSalesAmount { get; set; }
    }
}