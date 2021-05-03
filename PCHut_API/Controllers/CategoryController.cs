using PCHut_API.Models;
using PCHut_API.Repository;
using PCHut_API.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private CategoryRepository CategoryRepository = new CategoryRepository();

        [Route(""), HttpGet]
        public IHttpActionResult Get() //Get Product List
        {
            return Ok(CategoryRepository.GetAll());
        }
        [Route("{id}"), HttpGet]
        public IHttpActionResult Get(int id)
        {
            Category category = CategoryRepository.Get(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(CategoryRepository.Get(id));
        }
        [Route("", Name = "CategoryPath"), HttpPost]
        public IHttpActionResult Create(Category category)
        {
            CategoryRepository.Insert(category);
            string url = Url.Link("CategoryPath", new { id = category.CategoryId });
            return Created(url,category);
        }
        [Route("{id}"), HttpPut]
        public IHttpActionResult Edit([FromBody] Category category, [FromUri] int id)
        {
            category.CategoryId = id;
            CategoryRepository.Update(category);
            return Ok(category);
        }
        [Route("{id}"), HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            CategoryRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("TopCategoryGraph/{id}"), HttpGet]
        public IHttpActionResult TopCategoryGraph(int id)
        {
            List<TopCategoryViewModel> tcvm = new List<TopCategoryViewModel>();
            tcvm = CategoryRepository.TopCategory(id);
            var newList = tcvm.OrderBy(x => x.Quantity);
            var revList=newList.Reverse();// categoryId with highest quanity goes on top of list

            List<BarChartModel> barCharts = new List<BarChartModel>();
            foreach(var item in revList)
            {
                
                string catName = CategoryRepository.Get(item.Id).Name; 
                BarChartModel barChart = new BarChartModel(catName,(double)item.Quantity);
                barCharts.Add(barChart);
            }
            var lsitOfData = Newtonsoft.Json.JsonConvert.SerializeObject(barCharts);

            return Ok(barCharts);
        }

        [HttpGet, Route("categoryProductAmountChart")]
        public IHttpActionResult CategoryProductAmountChart()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var list = categoryRepository.NumberOfProductsInCategory();

            List<BarChartModel> categoriesProductAmount = new List<BarChartModel>();

            foreach (var data in list)
            {
                BarChartModel chart = new BarChartModel(data.Name, data.Count);
                categoriesProductAmount.Add(chart);
            }

            return Ok(categoriesProductAmount);
        }
    }
}
