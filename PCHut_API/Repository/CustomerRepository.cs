using PCHut_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCHut_API.View_Model;

namespace PCHut_API.Repository
{
    public class CustomerRepository : Repository<Customer>
    {
        PcHutDbContext context = new PcHutDbContext();
    }
}