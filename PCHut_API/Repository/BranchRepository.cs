using PCHut_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCHut_API.Repository
{
    public class BranchRepository:Repository<Branch>
    {
        

        public List<Branch> GetBranchInfo(int id)
        {
            List<Branch> branchInfo = context.Database.SqlQuery<Branch>("select * from Branches where BranchId in (select BranchId from Branches where BranchId not in(select BranchId from DistributedProducts where ProductId = "+id+"))").ToList();
            return branchInfo;
        }
    }
}