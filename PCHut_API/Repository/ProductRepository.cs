using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.Repository;
using PCHut_API.Models;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace PCHut_API.Repository
{
    public class ProductRepository : Repository<Product>
    {
        private PcHutDbContext context = new PcHutDbContext();

        public Product TopLaptop()
        {
            var laptop = context.Products.SqlQuery(@"select * from Products where Product_id in (select top 1 Product_id from Sales_record where Product_id in (select Product_id from Products where Category_id = (select Category_id from Categories where Categories.Name = 'laptop')) group by Product_id order by sum(Quantity) desc)").First();
            return laptop;
        }
    }
}