using DDLPerson.Model;
using DDLPerson.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDLPerson.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        List<EmployeeView> ddlEmployees;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEmployees = EmployeeViewRepo.GetAll();
                ddlPerson.DataSource = ddlEmployees;
                ddlPerson.DataValueField = "EmployeeId";
                ddlPerson.DataTextField = "FullName";
                ddlPerson.DataBind();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Employee emp = EmployeeRepo.Get(Convert.ToInt32(ddlPerson.SelectedValue));
            lblFirstName.Text = emp.FirstName;
            lblLastName.Text = emp.LastName;
            lblBirthday.Text = emp.DateBirthday.ToShortDateString();
            lblINN.Text = emp.INN;
        }
    }
}