using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbxInput.Items.Add("Item One");
            lbxInput.Items.Add("Item Two");
            lbxInput.Items.Add("Item Three");
            lbxInput.Items.Add("Item Four");
        }
    }
}