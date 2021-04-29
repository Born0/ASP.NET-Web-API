using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using PCHut_API.Attribute;
using PCHut_API.Models;
using PCHut_API.Repository;
using PCHut_API.View_Model;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/branchManagers")]
    //Thread.CurrentPrincipal.Identity.Name == "admin"----Authentication
    public class BranchManagerController : ApiController
    {
        BranchManagerRepository BranchManagerRepository = new BranchManagerRepository();
        [Route(""),HttpGet, BasicAthentication]
        public IHttpActionResult Get() 
        {
            return Ok(BranchManagerRepository.GetAll());
        }

        [Route("{id}"), HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(BranchManagerRepository.Get(id));
        }

        [Route("", Name = "BranchManagerPath"), HttpPost]
        public IHttpActionResult Create(BranchManager branch_Manager)
        {
           if(ModelState.IsValid)
            {
                BranchManagerRepository.Insert(branch_Manager);
                string url = Url.Link("BranchManagerPath", new { id = branch_Manager.BranchManagerId });
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

        [HttpGet, Route("topSeller")]
        public IHttpActionResult TopSeller() //topSellerBranchManager
        {
            BranchManagerRepository branchManagerRepository = new BranchManagerRepository();
            TopBranchManagerModel branchManager = branchManagerRepository.BranchManagerInfo();

            return Ok(branchManager);
        }
    }
}
