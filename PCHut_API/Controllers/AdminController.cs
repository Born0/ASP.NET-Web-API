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
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private AdminRepository adminRepository = new AdminRepository();
        [Route(""), HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(adminRepository.GetAll());
        }
        [Route("", Name = "AdminPath"), HttpPost]
        public IHttpActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                adminRepository.Insert(admin);
                string url = Url.Link("AdminPath", new { id = admin.AdminId });
                return Created(url, admin);
            }
            else
            {
                return StatusCode(HttpStatusCode.ExpectationFailed);
            }
        }
    }
}
