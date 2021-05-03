using PCHut_API.Repository;
using PCHut_API.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/invoices")]
    public class InvoiceController : ApiController
    {
        private InvoiceRepository invoiceRepository = new InvoiceRepository(); 
         
        [Route("DiscountReport"), HttpGet]
        public IHttpActionResult DiscountReportByBranch()
        {
            List<DiscountViewModel> discountModels = new List<DiscountViewModel>();
            List<DiscountReportViewModel> model = new List<DiscountReportViewModel>();
            model = invoiceRepository.DiscountReportByBranch();
            foreach(var item in model)
            {
                DiscountViewModel discount = new DiscountViewModel();
                discount.Branch_Id = item.BranchId;
                discount.Column1 = item.Discount;
                discountModels.Add(discount);
            }

            List<BarChartModel> barCharts = new List<BarChartModel>();
            foreach(DiscountViewModel item in discountModels)
            {
                DiscountViewModel dvm = new DiscountViewModel();
                BranchRepository branch = new BranchRepository();
                string branchName = branch.Get(item.Branch_Id).Name;
                dvm.Column1 = item.Column1;

                BarChartModel barChart = new BarChartModel(branchName, (double)dvm.Column1);
                barCharts.Add(barChart);
            }
            var lsitOfData = Newtonsoft.Json.JsonConvert.SerializeObject(barCharts);

            return Ok(barCharts);

 
        }
    }
}
