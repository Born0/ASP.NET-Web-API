using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.Models;
using System.Data.Entity.Infrastructure;

namespace PCHut_API.Repository
{
    public class DistributedProductRepository : Repository<DistributedProduct>
    {
        

        public List<DistributedProduct> ProductQuantityByBranch(int id)
        {
            List<DistributedProduct> productsQuantity = context.Database.SqlQuery<DistributedProduct>("select * from DistributedProducts where ProductId = "+id+";").ToList();
            return productsQuantity;
        }
    }
}