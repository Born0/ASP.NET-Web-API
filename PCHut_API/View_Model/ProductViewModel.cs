using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PCHut_API.Models;

namespace PCHut_API.View_Model
{
    [NotMapped]
    public class ProductViewModel
    {
        public HttpPostedFileBase ProductPic { get; set; }
    }
}