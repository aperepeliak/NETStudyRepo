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

    protected void btnWriteCookie_Click(object sender, EventArgs e)
    {
        HttpCookie cookies = new HttpCookie(txtCookieName.Text, txtCookieValue.Text);

        cookies.Expires = DateTime.Now.AddMonths(3);
        Response.Cookies.Add(cookies);
    }

    protected void btnShowCookie_Click(object sender, EventArgs e)
    {
        string cookieData = string.Empty;

        foreach (string s in Request.Cookies)
        {
            cookieData += $"<li><b>Name:</b>{s}, <b>Value</b>: {Request.Cookies[s]?.Value}</li>";
        }

        lblCookieData.Text = cookieData;
    }
}