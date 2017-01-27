using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Annotations : System.Web.UI.Page
{
    private Inventory _model = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void SaveCar(Inventory car)
    {
        if (ModelState.IsValid)
        {
            _model = car;
        }
    }

    public void UpdateCar(int carID)
    {
        Inventory car = new Inventory();
        if(TryUpdateModel(car))
        {
            _model = car;
        }
    }

    public Inventory GetCar() => _model;
}