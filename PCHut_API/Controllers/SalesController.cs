using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCHut_API.Models;
using PCHut_API.View_Model;
using PCHut_API.Repository;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/sales")]
    public class SalesController : ApiController
    {
        PcHutDbContext context = new PcHutDbContext();

        [HttpGet, Route("yearlySalesReports")]
        public IHttpActionResult YearlySalesReport()
        {
            SalesRepository salesRepository = new SalesRepository();

            List<SumGroupByModel> yearlySalesInfo= salesRepository.GetYearlySalesData();
            return Ok(yearlySalesInfo);
        }

        [HttpGet, Route("monthlySalesForYearReports/{year}")]
        public IHttpActionResult MonthlySalesForYearReport(int year)
        {
            SalesRepository salesRepository = new SalesRepository();

            List<SumGroupByModel> monthlyInfoForYear = salesRepository.GetMonthlySalesDataForAYear(year);
            monthlyInfoForYear = salesRepository.GetMonthlySalesDataForAYear(year);

            List<BarChartModel> chart = new List<BarChartModel>();

            string[] months = { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };

            int i, j;
            int count = monthlyInfoForYear.Count();

            //Adding All the Months and Giving the Sum Amount Zero to the chart
            for (i = 0; i < 12; i++)
            {
                BarChartModel barChartModel = new BarChartModel(months[i], 0);
                chart.Add(barChartModel);
            }

            //Now Assigning Value to the months where the Sum Amount exists for that particular month
            for (i = 0; i < count; i++)
            {
                chart[monthlyInfoForYear[i].Id - 1].Y = monthlyInfoForYear[i].Column1;
            }
            return Ok(chart);
        }
    }
}
