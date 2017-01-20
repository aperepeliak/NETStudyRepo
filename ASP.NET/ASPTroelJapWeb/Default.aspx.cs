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

    }

    protected void btnGetBrowserStats_Click(object sender, EventArgs e)
    {
        string theInfo = string.Empty;
        theInfo += $"<li>Is the client AOL {Request.Browser.AOL}</li>";
        theInfo += $"<li>Does the client support ActiveX? {Request.Browser.ActiveXControls}</li>";
        theInfo += $"<li>Is the client a Beta? {Request.Browser.Beta}</li>";
        theInfo += $"<li>Does the client support Java Applets? {Request.Browser.JavaApplets}</li>";
        theInfo += $"<li>Does the client support Cookies? {Request.Browser.Cookies}</li>";
        theInfo += $"<li>Does the client support VBScript? {Request.Browser.VBScript}</li>";

        lblOutput.Text = theInfo;
    }

    protected void btnGetFormData_Click(object sender, EventArgs e)
    {
        string firstName = txtFirstName.Text;
    }

    protected void btnHttpResponse_Click(object sender, EventArgs e)
    {
        Response.Write("<b>My name is:</b><br>");
        Response.Write(this.ToString());
    }
}