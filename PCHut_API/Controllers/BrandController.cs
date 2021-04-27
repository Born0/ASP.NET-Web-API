using PCHut_API.Models;
using PCHut_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCHut_API.View_Model;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/brands")]
    public class BrandController : ApiController
    {
        private BrandRepository brandRepository = new BrandRepository();

        [Route(""),HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(brandRepository.GetAll());
        }
        [Route("{id}"),HttpGet]
        public IHttpActionResult Get(int id)
        {
            Brand brand = brandRepository.Get(id);
            if (brand == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(brand);
        }

        [Route("", Name = "BrandPath"), HttpPost]
        public IHttpActionResult Create(Brand brand)
        {
            brandRepository.Insert(brand);
            string url = Url.Link("BrandPath", new { id = brand.BrandId });
            return Created(url, brand);
        }
        [Route("{id}"), HttpPut]
        public IHttpActionResult Edit([FromBody] Brand brand, [FromUri] int id)
        {
            brand.BrandId = id;
            brandRepository.Update(brand);
            return Ok(brand);
        }
        [Route("{id}"), HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            brandRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet, Route("topBrandDetails")]
        public IHttpActionResult TopBrandDetails()
        {
            ProductRepository product = new ProductRepository();

            DefaultViewModel productInfo = new DefaultViewModel();
            productInfo = product.ProductInfoForTopBrand();

            BrandRepository brandDetails = new BrandRepository();
            Brand brand = brandDetails.BrandDetails(productInfo.Id);

            return Ok(brand);
        }
    }
}
