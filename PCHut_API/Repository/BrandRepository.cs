using PCHut_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.Controllers;
using PCHut_API.View_Model;

namespace PCHut_API.Repository
{
    public class BrandRepository : Repository<Brand>
    {
        

        public Brand BrandDetails(int bId)
        {
            Brand brand = context.Database.SqlQuery<Brand>("select * from Brands where BrandId = (select BrandId from Products where ProductId = "+bId+")").First();
            return brand;
        }

        public List<TopCategoryViewModel> TopBrands(int id)
        {
            var invoices = this.context.Invoices.Where(x => x.BranchId == id).Select(x => x.CustomerId).ToList();
            List<TopCategoryViewModel> Ids = new List<TopCategoryViewModel>();
            foreach (var item in invoices)
            {
                var products = context.SalesRecords.Where(x => x.CustomerId == item).Select(x => new { x.ProductId, x.Quantity }).ToList();
                foreach (var pr in products)
                {
                    TopCategoryViewModel tcvm = new TopCategoryViewModel();
                    tcvm.Id = pr.ProductId;
                    tcvm.Quantity = pr.Quantity;
                    Ids.Add(tcvm);
                }
            }

            List<int> brandIds = new List<int>();
            foreach(var item in Ids)
            {
                var brandId = context.Products.Where(x => x.ProductId == item.Id).Select(x => new { x.BrandId }).FirstOrDefault();
                brandIds.Add(brandId.BrandId);
            }
            for(int i=0; i<Ids.Count; i++)
            {
                Ids[i].Id = brandIds[i];
            }

            return Ids;
        }
    }
}