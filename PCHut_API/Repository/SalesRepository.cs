using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.Models;
using PCHut_API.View_Model;

namespace PCHut_API.Repository
{
    public class SalesRepository
    {
        PcHutDbContext context = new PcHutDbContext();

        public List<SumGroupByModel> GetYearlySalesData()
        {
            List<SumGroupByModel> yearlySalesReport = context.Database.SqlQuery<SumGroupByModel>("select sum(TotalAmount) as Column1, YEAR(Date) as Id from Invoices group by YEAR(Date)").ToList();
            return yearlySalesReport;
        }

        public List<SumGroupByModel> GetMonthlySalesDataForAYear(int year)
        {
            List<SumGroupByModel> monthlyInfoByForYear = context.Database.SqlQuery<SumGroupByModel>("select sum(TotalAmount) as Column1, Month(Date) as Id from Invoices where YEAR(date) = "+year+" group by MONTH(Date)").ToList();

            return monthlyInfoByForYear;
        }

    }
}