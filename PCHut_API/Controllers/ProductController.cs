using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCHut_API.Repository;
using PCHut_API.Models;
using System.Data.Entity.Infrastructure;

namespace PCHut_API.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get() //Get Product List
        {
            ProductRepository products = new ProductRepository();
            var allProducts = products.GetAll();
            return Ok(allProducts);
        }

        [HttpGet]
        public IHttpActionResult Get(int id) //Get Single Product
        {
            ProductRepository productRepository = new ProductRepository();
            Product singleProduct = productRepository.Get(id);
            if (singleProduct == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(singleProduct);
        }

        [HttpPost]
        public IHttpActionResult Post(Product product) //Creating Product
        {
            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            ProductRepository productRepository = new ProductRepository();
            productRepository.Insert(product);
            return Created("abc", product);
        }

        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Product product) //Edit Product
        {
            product.Product_id = id;
            ProductRepository productRepository = new ProductRepository();
            productRepository.Update(product);
            return Ok(product);
        }

        [HttpPut]
        [Route("api/products/changeProductStatus/{id}/{branchId}")]
        public IHttpActionResult ChangeProductStatus(int id /*productId*/, int branchId /*branchId*/) //Change Product Status
        {
            ProductRepository product1 = new ProductRepository();
            Product singleProduct = product1.Get(id);

            if (singleProduct.Status == 1)
            {
                singleProduct.Status = 0;
                product1.Update(singleProduct);
            }
            else
            {
                singleProduct.Status = 1;
                product1.Update(singleProduct);
            }

            return Ok(singleProduct);
        }

        [HttpGet]
        [Route("api/products/topLaptopDetails")]
        public IHttpActionResult TopLaptopDetails()
        {
            ProductRepository products = new ProductRepository();
            Product laptop = products.TopLaptop();
            return Ok(laptop);
        }
    }
}
