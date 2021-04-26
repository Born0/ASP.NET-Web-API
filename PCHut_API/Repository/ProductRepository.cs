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

        public List<Product> Search(string name)
        {
            
            return this.context.Products.Where(x => x.ProductName.Contains(name)).ToList();
        }
        public List<Product> SearchByType(string type)
        {
            List<Product> products = this.context.Products.Where(x => x.Special == type).ToList();
            return products;
        }
        public List<Product> PriceFilter(float min, float max)
        {
            List<Product> products = this.context.Products.Where(x => x.Price >= min && x.Price <= max).ToList();
            return products;
        }

    }
}