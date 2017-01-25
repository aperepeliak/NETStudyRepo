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

    protected void btnShowCarOnSale_Click(object sender, EventArgs e)
    {
        CarLotInfo appVars =
            ((CarLotInfo)Application["CarSiteInfo"]);

        string appState = $"<li>Car on sale: {appVars.CurrentCarOnSale}</li>";
        appState += $"<li>Most popular color: {appVars.MostPopularColorOnLot}</li>";
        appState += $"<li>Big shot SalesPerson: {appVars.SalesPersonOfTheMonth}</li>";

        lblResult.Text = appState;
    }

    protected void btnSetNewSalesPerson_Click(object sender, EventArgs e)
    {
        ((CarLotInfo)Application["CarSiteInfo"]).SalesPersonOfTheMonth = txtNewSales.Text;
    }
}