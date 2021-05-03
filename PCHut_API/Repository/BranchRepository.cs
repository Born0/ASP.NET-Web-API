using PCHut_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.View_Model;

namespace PCHut_API.Repository
{
    public class BranchRepository:Repository<Branch>
    {
        PcHutDbContext context = new PcHutDbContext();

        public List<Branch> GetBranchInfo(int id)
        {
            List<Branch> branchInfo = context.Database.SqlQuery<Branch>("select * from Branches where BranchId in (select BranchId from Branches where BranchId not in(select BranchId from DistributedProducts where ProductId = "+id+"))").ToList();
            return branchInfo;
        }

        public List<SumGroupByModel> AllBranchSales()
        {
            List<SumGroupByModel> branchSales = context.Database.SqlQuery<SumGroupByModel>("select branchId as Id, sum(totalAmount) as Column1 from Invoices group by branchId").ToList();

            return branchSales;
        }

        public List<SumGroupByModel> SingleBranch(int id)
        {
            List<SumGroupByModel> branchYearlySales = context.Database.SqlQuery<SumGroupByModel>("select sum(TotalAmount) as Column1, YEAR(Date) as Id from invoices where BranchId = "+id+" group by YEAR(date)").ToList();

            return branchYearlySales;
        }

        public List<SumGroupByModel> SingleBranchMonthlySales(int id, int year)
        {
            List<SumGroupByModel> branchYearlySales = context.Database.SqlQuery<SumGroupByModel>("select sum(totalAmount) as Column1, MONTH(Date) as Id from Invoices where YEAR(date) = "+year+" and BranchId = "+id+" group by MONTH(Date)").ToList();

            return branchYearlySales;
        }
        
        public SumGroupByModel TopSellingBranch()
        {
            SumGroupByModel topBranch = context.Database.SqlQuery<SumGroupByModel>("select branchId as Id, sum(totalAmount) as Column1 from Invoices group by branchId order by sum(TotalAmount) desc").First();

            return topBranch;
        }
    }
}