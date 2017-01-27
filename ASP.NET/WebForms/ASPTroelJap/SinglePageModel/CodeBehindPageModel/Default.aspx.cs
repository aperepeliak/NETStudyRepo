using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AutoLotDAL.Models;
using AutoLotDAL.Repos;

namespace CodeBehindPageModel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<Inventory> GetData()
        {
            Trace.Write("Default.aspx", "Getting Data");
            return new InventoryRepo().GetAll();
        }
    }
}