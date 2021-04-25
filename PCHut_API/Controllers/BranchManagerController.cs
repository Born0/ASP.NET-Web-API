using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCHut_API.Models;
using PCHut_API.Repository;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/branchManager")]
    public class BranchManagerController : ApiController
    {
        BranchManagerRepository BranchManagerRepository = new BranchManagerRepository();
        [Route(""),HttpGet]
        public IHttpActionResult Get() //Get Product List
        {
            return Ok(BranchManagerRepository.GetAll());
        }

        [Route("{id}"), HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(BranchManagerRepository.Get(id));
        }

        [Route("", Name = "Branch_ManagerPath"), HttpPost]
        public IHttpActionResult Create(BranchManager branch_Manager)
        {
           if(ModelState.IsValid)
            {
                BranchManagerRepository.Insert(branch_Manager);
                string url = Url.Link("Branch_ManagerPath", new { id = branch_Manager.BranchManagerId });
                return Created(url, branch_Manager);
            }
           else
            {
                return StatusCode(HttpStatusCode.ExpectationFailed);
            }
        }

        [Route("{id}"), HttpPut]
        public IHttpActionResult Edit([FromBody] BranchManager branch_Manager, [FromUri] int id)
        {
            branch_Manager.BranchManagerId = id;
            BranchManagerRepository.Update(branch_Manager);
            return Ok(branch_Manager);
        }

        // DELETE api/<controller>/5
        [Route("{id}"), HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            BranchManagerRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
