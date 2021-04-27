using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCHut_API.Repository;
using PCHut_API.Models;
namespace PCHut_API.Controllers
{
    [RoutePrefix("api/distributedProducts")]
    public class DistributedProductController : ApiController
    {
        private DistributedProductRepository DistributedProductRepository = new DistributedProductRepository();

        [HttpGet, Route("")]
        public IHttpActionResult Get() //Get Product List
        {
            List<DistributedProduct> products = DistributedProductRepository.GetAll();
            if (products == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
                return Ok(products);
        }
        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id) //Get Single Product
        {
            DistributedProduct product = DistributedProductRepository.Get(id);
            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
                return Ok(product);
            
        }
        [Route("", Name="DistributedProduct"), HttpPost]
        public IHttpActionResult Create(DistributedProduct product)
        {
            if(product==null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                DistributedProductRepository.Insert(product);
                string url = Url.Link("DistributedProduct", new { id =product.DistributedProductId });
                return Created(url, product);

            }

        }
        [Route("{id}"), HttpPut]
        public IHttpActionResult Edit([FromBody] DistributedProduct product,[FromUri] int id)
        {
            product.DistributedProductId = id;
            DistributedProductRepository.Update(product);
            return Ok(product);
        }






    }
}
