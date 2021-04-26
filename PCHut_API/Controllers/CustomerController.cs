using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCHut_API.Models;
using PCHut_API.View_Model;
using PCHut_API.Repository;

namespace PCHut_API.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        
        private PcHutDbContext context;

        [HttpGet, Route("topThreeCustomerGraph")]
        public IHttpActionResult TopThreeCustomerGraph()
        {
            context = new PcHutDbContext();
            var list1 = context.Database.SqlQuery<TopCustomerViewModel>("select top 3 CustomerId as User_id, sum(Invoices.TotalAmount) as Column1 from Invoices group by CustomerId order by sum(Invoices.TotalAmount) desc").ToList();

            List<BarChartModel> topThreeCustomers = new List<BarChartModel>();

            foreach (TopCustomerViewModel topThree in list1)
            {
                TopCustomerViewModel tcvm = new TopCustomerViewModel();
                CustomerRepository user = new CustomerRepository();
                var userDetails = user.Get(topThree.User_Id);

                Customer userInfo = new Customer();
                userInfo.Name = userDetails.Name;

                //tcvm.User_Id = topThree.User_Id;
                tcvm.Column1 = topThree.Column1;

                BarChartModel topChartModel = new BarChartModel(userInfo.Name, (double)tcvm.Column1);
                topThreeCustomers.Add(topChartModel);
            }

            var listofData = Newtonsoft.Json.JsonConvert.SerializeObject(topThreeCustomers);

            //foreach()

            return Ok(topThreeCustomers);
        }
    }
}
