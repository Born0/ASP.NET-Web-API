using PCHut_API.Models;
using PCHut_API.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCHut_API.Repository
{
    public class InvoiceRepository: Repository<Invoice>
    {
        public List<DiscountReportViewModel> DiscountReportByBranch()
        {
           List<DiscountReportViewModel> models = new List<DiscountReportViewModel>();
           var discountReport = context.Database.SqlQuery<DiscountReportViewModel>("SELECT BranchId as BranchId, sum (TotalAmount) as Total, sum (AddedSubTotal) as SubTotal FROM Invoices group by BranchId").ToList();
           foreach(var item in discountReport)
            {
                item.Discount = item.SubTotal - item.Total;
                models.Add(item);
            }
            return models;
        }
    }
}