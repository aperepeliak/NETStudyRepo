﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportDataToOfficeApp
{
    public partial class NewCarDialog : Form
    {

        public Car theCar = null;

        public NewCarDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            theCar = new Car { Color = lstColor.Text, Make = lstMakes.Text, PetName = txtCarName.Text };
        }
    }
}
