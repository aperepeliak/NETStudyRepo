using AutoLotDAL.Models;
using AutoLotDAL.Repos;
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
            dgvCars.DataSource = (IList<Inventory>)Cache["CarList"];
            dgvCars.DataBind();
        }
    }

    protected void btnAddCar_Click(object sender, EventArgs e)
    {
        new InventoryRepo().Add(new Inventory()
        {
            Color = txtColor.Text,
            Make = txtMake.Text,
            PetName = txtPetName.Text
        });

        RefreshGrid();
    }

    private void RefreshGrid()
    {
        dgvCars.DataSource = new InventoryRepo().GetAll();
        dgvCars.DataBind();
    }
}