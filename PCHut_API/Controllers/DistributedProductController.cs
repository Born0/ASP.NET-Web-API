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
        [HttpGet, Route("")]
        public IHttpActionResult Get() //Get All Products Stock List By Branch
        {
            DistributedProductRepository products = new DistributedProductRepository();
            var allProductsByBranch = products.GetAll();
            return Ok(allProductsByBranch);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            DistributedProductRepository productRepository = new DistributedProductRepository();
            List<DistributedProduct> singleProductStockInBranch = productRepository.ProductQuantityByBranch(id);
            if (singleProductStockInBranch == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(singleProductStockInBranch);
        }

        [HttpGet, Route("editQuantityByBranch/{id}")]
        public IHttpActionResult UpateQuantity(int id)
        {
            DistributedProductRepository productRepository = new DistributedProductRepository();
            List<DistributedProduct> singleProductStockInBranch = productRepository.ProductQuantityByBranch(id);
            if (singleProductStockInBranch == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(singleProductStockInBranch);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post(DistributedProduct distributedProduct)
        {
            if (distributedProduct == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            distributedProduct.Status = 1;
            DistributedProductRepository productRepository = new DistributedProductRepository();
            productRepository.Insert(distributedProduct);
            return Created("abc", distributedProduct);
        }

        [HttpPut]
        [Route("changeProductStatusInBranch/{id}")]
        public IHttpActionResult ChangeProductStatusInBranch(int id)
        {
            DistributedProductRepository distributedProductId = new DistributedProductRepository();
            DistributedProduct distributedProduct = distributedProductId.Get(id);

            if (distributedProduct.Status == 1)
            {
                distributedProduct.Status = 0;
                distributedProductId.Update(distributedProduct);
            }
            else
            {
                distributedProduct.Status = 1;
                distributedProductId.Update(distributedProduct);
            }

            return Ok(distributedProduct);
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] DistributedProduct product)
        {
            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            product.DistributedProductId = id;
            DistributedProductRepository distributedProductRepository = new DistributedProductRepository();
            distributedProductRepository.Update(product);
            return Ok(product);
        }
    }
}
