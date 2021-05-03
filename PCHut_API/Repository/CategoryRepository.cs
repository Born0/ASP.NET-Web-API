using PCHut_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.View_Model;

namespace PCHut_API.Repository
{
    public class CategoryRepository: Repository<Category>
    {
       

        public List<CategoryProductViewModel> NumberOfProductsInCategory()
        {
            var list = context.Database.SqlQuery<CategoryProductViewModel>("select Name as Name, count(Products.CategoryId) as Count from Categories, Products where Categories.CategoryId = Products.CategoryId and Categories.CategoryId in ( select CategoryId from Products group by CategoryId) group by Categories.Name");

            List<CategoryProductViewModel> info = new List<CategoryProductViewModel>();

            foreach (CategoryProductViewModel data in list)
            {
                info.Add(data);
            }

            return info;
        }
        public List<TopCategoryViewModel> TopCategory(int id)
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
            List<int> categoryId = new List<int>();
            foreach (var item in Ids)
            {
                var catIds = context.Products.Where(x => x.ProductId == item.Id).Select(x => new { x.CategoryId }).FirstOrDefault();
                categoryId.Add(catIds.CategoryId);
            }
            for (int i = 0; i < Ids.Count; i++)
            {
                Ids[i].Id = categoryId[i];
            }

            return Ids;

        }

    }
}