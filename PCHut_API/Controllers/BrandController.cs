using PCHut_API.Models;
using PCHut_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/brand")]
    public class BrandController : ApiController
    {
        private BrandRepository brandRepository = new BrandRepository();

        [Route(),HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(brandRepository.GetAll());
        }
        [Route("{id}"),HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(brandRepository.Get(id));
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

    }
}
