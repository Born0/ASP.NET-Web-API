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
        PcHutDbContext context = new PcHutDbContext();

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
    }
}