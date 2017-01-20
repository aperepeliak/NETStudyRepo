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
        ListControlsInPanel();
    }

    private void ListControlsInPanel()
    {
        var theInfo = string.Empty;

        theInfo = $"<b>Does the panel have controls? {myPanel.HasControls()}</b><br/>";

        foreach (Control c in myPanel.Controls)
        {
            if (!object.ReferenceEquals(c.GetType(), typeof(System.Web.UI.LiteralControl)))
            {
                theInfo += $"*********************<br/>";
                theInfo += $"Control name? {c} <br/>";
                theInfo += $"ID? {c.ID} <br/>";
                theInfo += $"Control visible? {c.Visible} <br/>";
                theInfo += $"ViewState? {c.EnableViewState} <br/>";
            }
        }
        lblControlInfo.Text = theInfo;
    }

    protected void btnAddWidgets_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            var txtb = new TextBox { ID = $"newTextBox{i}" };
            myPanel.Controls.Add(txtb);
            ListControlsInPanel();
        }
    }

    protected void btnClearPanel_Click(object sender, EventArgs e)
    {
        myPanel.Controls.Clear();
        ListControlsInPanel();
    }

    protected void btnGetTxtData_Click(object sender, EventArgs e)
    {
        string lableData = $"<li>{Request.Form.Get("newTextBox0")}</li><br/>";
        lableData += $"<li>{Request.Form.Get("newTextBox1")}</li><br/>";
        lableData += $"<li>{Request.Form.Get("newTextBox2")}</li><br/>";
        lblTextBoxData.Text = lableData;
    }
}