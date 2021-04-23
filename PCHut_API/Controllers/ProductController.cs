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
    }
}
