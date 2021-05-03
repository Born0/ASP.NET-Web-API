using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCHut_API.View_Model
{
    public class DiscountReportViewModel
    {
        public int BranchId { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }

    }
}