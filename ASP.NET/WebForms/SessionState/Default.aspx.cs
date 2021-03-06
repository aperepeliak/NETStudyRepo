﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUserId.Text = $"\tUser ID: {Session.SessionID}";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var cart = (UserShoppingCart)Session["UserShoppingCartInfo"];

        cart.DateOfPickUp = Calendar1.SelectedDate;
        cart.DesiredCar = txtMake.Text;
        cart.DesiredCarColor = txtColor.Text;
        cart.DownPayment = float.Parse(txtDownPayment.Text);
        cart.IsLeasing = chkIsLeasing.Checked;

        lblUserInfo.Text = cart.ToString();

        Session["UserShoppingCartInfo"] = cart;
    }
}