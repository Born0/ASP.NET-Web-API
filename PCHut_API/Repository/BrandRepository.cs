using PCHut_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.Controllers;

namespace PCHut_API.Repository
{
    public class BrandRepository : Repository<Brand>
    {
        PcHutDbContext context = new PcHutDbContext();

        public Brand BrandDetails(int bId)
        {
            Brand brand = context.Database.SqlQuery<Brand>("select * from Brands where BrandId = (select BrandId from Products where ProductId = "+bId+")").First();
            return brand;
        }
    }
}