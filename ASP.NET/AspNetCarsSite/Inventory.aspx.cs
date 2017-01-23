using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AutoLotDAL.Models;
using AutoLotDAL.Repos;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public IQueryable<Inventory> GetData() => new InventoryRepo().GetAll().AsQueryable();

    // The id parameter name should match the DataKeyNames value set on the control
    public void GridView1_DeleteItem(int carID)
    {
        new InventoryRepo().Delete(carID);
    }

    public async void GridView1_UpdateItem(Inventory inventory)
    {
        if (ModelState.IsValid)
        {
            await new InventoryRepo().SaveAsync(inventory);
        }
    }
}