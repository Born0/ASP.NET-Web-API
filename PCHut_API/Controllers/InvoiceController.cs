using PCHut_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/invoices")]
    public class InvoiceController : ApiController
    {
        private InvoiceRepository invoiceRepository = new InvoiceRepository(); 
         
        [Route("DiscountReport"), HttpGet]
        public IHttpActionResult DiscountReportByBranch()
        {
           return Ok( invoiceRepository.DiscountReportByBranch());
        }
    }
}
