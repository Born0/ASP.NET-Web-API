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
    [RoutePrefix("api/branches")]
    public class BranchController : ApiController
    {
        private BranchRepository branchRepository = new BranchRepository();
        [Route(""), HttpGet]
        public IHttpActionResult Get() //Get Product List
        {
               return Ok(branchRepository.GetAll());
        }

        [Route("{id}"), HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(branchRepository.Get(id));
        }

        [Route("", Name = "BranchPath"), HttpPost]
        public IHttpActionResult Create(Branch branch)
        {
            branchRepository.Insert(branch);
            string url = Url.Link("BranchPath", new { id = branch.BranchId });
            return Created(url, branch);
        }

        [Route("{id}"), HttpPut]
        public IHttpActionResult Edit([FromBody] Branch branch, [FromUri] int id)
        {
            branch.BranchId = id;
            branchRepository.Update(branch);
            return Ok(branch);
        }

        //DELETE apicontroller5
        [Route("{id}"), HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            branchRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet, Route("getBranchNotAssignedForProduct/{id}")]
        public IHttpActionResult GetBranchNotAssignedForProduct(int id /*productId*/) //this method is called to get branch info where the particular product is not assigned
        {
            BranchRepository branchRepository = new BranchRepository();
            List<Branch> branchInfo = branchRepository.GetBranchInfo(id);
            return Ok(branchInfo);
        }
    }
}