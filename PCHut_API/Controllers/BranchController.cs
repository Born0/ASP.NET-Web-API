using PCHut_API.Models;
using PCHut_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCHut_API.View_Model;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/branches")]
    public class BranchController : ApiController
    {
        private BranchRepository branchRepository = new BranchRepository();
        [Route(""), HttpGet]
        public IHttpActionResult Get() //Get Product List
        {
               return Ok(branchRepository.GetAll());
        }

        [Route("{id}"), HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(branchRepository.Get(id));
        }

        [Route("", Name = "BranchPath"), HttpPost]
        public IHttpActionResult Create(Branch branch)
        {
            branchRepository.Insert(branch);
            string url = Url.Link("BranchPath", new { id = branch.BranchId });
            return Created(url, branch);
        }

        [Route("{id}"), HttpPut]
        public IHttpActionResult Edit([FromBody] Branch branch, [FromUri] int id)
        {
            branch.BranchId = id;
            branchRepository.Update(branch);
            return Ok(branch);
        }

        //DELETE apicontroller5
        [Route("{id}"), HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            branchRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet, Route("getBranchNotAssignedForProduct/{id}")]
        public IHttpActionResult GetBranchNotAssignedForProduct(int id /*productId*/) //this method is called to get branch info where the particular product is not assigned
        {
            BranchRepository branchRepository = new BranchRepository();
            List<Branch> branchInfo = branchRepository.GetBranchInfo(id);
            return Ok(branchInfo);
        }

        [HttpGet, Route("branchReportSales")]
        public IHttpActionResult SalesInfoByBranch()
        {
            BranchRepository branchRepository = new BranchRepository();
            var list = branchRepository.AllBranchSales();
            List<BranchSalesViewModel> branchList = new List<BranchSalesViewModel>();

            foreach (SumGroupByModel sgm in list)
            {
                BranchRepository repository = new BranchRepository();

                Branch branchDetails = repository.Get(sgm.Id);
                BranchSalesViewModel bsvm = new BranchSalesViewModel();

                bsvm.Id = sgm.Id;
                bsvm.BranchName = branchDetails.Name;
                bsvm.TotalSalesAmount = sgm.Column1;

                branchList.Add(bsvm);
            }

            return Ok(branchList);
        }

        [HttpGet, Route("salesReportByBranch/{id}")]
        public IHttpActionResult SalesReportByBranch(int id)
        {
            BranchRepository branchRepository = new BranchRepository();
            List<SumGroupByModel> brvm = branchRepository.SingleBranch(id);

            List<BarChartModel> chart = new List<BarChartModel>();

            foreach(SumGroupByModel sumGroupByModel in brvm)
            {
                BarChartModel barChartModel = new BarChartModel(sumGroupByModel.Id.ToString(), sumGroupByModel.Column1);
                chart.Add(barChartModel);
            }

            return Ok(chart);
        }

        [HttpGet, Route("singleBranchMonthlySales/{id}/{year}")]
        public IHttpActionResult SingleBranchMonthlySales(int id, int year)
        {
            BranchRepository branchRepository = new BranchRepository();
            List<SumGroupByModel> brvm = branchRepository.SingleBranchMonthlySales(id, year);

            List<BarChartModel> chart = new List<BarChartModel>();

            string[] months = { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };

            int i, j;
            int count = brvm.Count();

            //Adding All the Months and Giving the Sum Amount Zero to the chart
            for(i = 0; i < 12; i++)
            {
                BarChartModel barChartModel = new BarChartModel(months[i], 0);
                chart.Add(barChartModel);
            }

            //Now the Assigning Value to the months where the Sum Amount exists for that particular month
            for (i = 0; i < count; i++)
            {
                chart[brvm[i].Id - 1].Y = brvm[i].Column1;
            }
            return Ok(chart);
        }
        
        [HttpGet, Route("topBranchDetails")]
        public IHttpActionResult TopBranchDetails()
        {
            SumGroupByModel branchSumAmount = branchRepository.TopSellingBranch();

            Branch branch = branchRepository.Get(branchSumAmount.Id);  
            
            TopBranchViewModel topSellingBranchDetails = new TopBranchViewModel();
            topSellingBranchDetails.Name = branch.Name;
            topSellingBranchDetails.Address = branch.Address;
            topSellingBranchDetails.TotalSalesAmount = branchSumAmount.Column1;

            return Ok(topSellingBranchDetails);
        }
    }
}