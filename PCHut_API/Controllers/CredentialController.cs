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
    [RoutePrefix("api/credentials")]
    public class CredentialController : ApiController
    {
        private CredentialRepository credentialRepository = new CredentialRepository();
        [Route(""), HttpGet]
        public IHttpActionResult Get() //Get Product List
        {
            return Ok(credentialRepository.GetAll());
        }

        [Route("{id}"), HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(credentialRepository.Get(id));
        }

        [Route("", Name = "CredentialPath"), HttpPost]
        public IHttpActionResult Create(Credential credential)
        {
            credentialRepository.Insert(credential);
            string url = Url.Link("CredentialPath", new { id = credential.CredentialId });
            return Created(url, credential);
        }

        [Route("{id}"), HttpPut]
        public IHttpActionResult Edit([FromBody] Credential credential, [FromUri] int id)
        {
           credential.CredentialId = id;
            credentialRepository.Update(credential);
            return Ok(credential);
        }

        [Route("{id}"), HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            credentialRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
