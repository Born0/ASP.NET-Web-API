using PCHut_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/ProductSearches")]
    public class ProductSearchController : ApiController
    {
        ProductRepository productRepository = new ProductRepository();
        [Route("SearchByName/{key}"), HttpGet]
        public IHttpActionResult SearchByName(string key)
        {
            return Ok(productRepository.Search(key));
        }
        [Route("SearchByType/{type}"), HttpGet]
        public IHttpActionResult SearchByType(string type)
        {
            return Ok(productRepository.SearchByType(type));
        }
        //price Filter -->
        [Route("PriceFilter/{max}/{min}"), HttpGet]
        public IHttpActionResult PriceFilter(float max, float min )
        {
            return Ok(productRepository.PriceFilter(min, max));
        }
        [Route("PriceFilterForMax/{max}"), HttpGet]
        public IHttpActionResult PriceFilterForMax(float max)
        {
            float min = 0;
            return Ok(productRepository.PriceFilter(min, max));
        }
        [Route("PriceFilterForMin/{min}"), HttpGet]
        public IHttpActionResult PriceFilterForMin(float min)
        {
            float max = float.MaxValue;
            return Ok(productRepository.PriceFilter(min, max));
        }
        //price Filter <--

        public IHttpActionResult SearchByCategory(int id)
        {  
            return Ok(productRepository.SearchByCategory(id));
        }
    }
}
