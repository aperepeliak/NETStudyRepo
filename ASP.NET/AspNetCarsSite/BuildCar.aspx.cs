using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuildCar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtPickName_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        string order = $"{txtPickName.Text}, your {lbxPickColor.SelectedValue} {txtPickModel.Text} will arrive on {calendarChooseDate.SelectedDate.ToShortDateString()}";

        lblOrder.Text = order;
    }
}