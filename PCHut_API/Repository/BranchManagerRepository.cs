using PCHut_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.View_Model;

namespace PCHut_API.Repository
{
    public class BranchManagerRepository : Repository<BranchManager>
    {
        

        public TopBranchManagerModel BranchManagerInfo()
        {
            SumGroupByModel branchManagerInfo = context.Database.SqlQuery<SumGroupByModel>("select top 1 sum(TotalAmount) as Column1, BranchManagerId as Id from Invoices group by BranchManagerId order by sum(TotalAmount) desc").First();

            //BranchManager manager = context.BranchManagers.Find(branchManagerInfo.Id);
            TopBranchManagerModel manager = context.Database.SqlQuery<TopBranchManagerModel>("select * from BranchManagers where BranchManagerId = "+ branchManagerInfo.Id).First();
            manager.SumAmount = branchManagerInfo.Column1;
            return manager;
        }
    }
}