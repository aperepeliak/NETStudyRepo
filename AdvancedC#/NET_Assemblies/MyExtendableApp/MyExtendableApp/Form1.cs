using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using CommonSnappableTypes;

namespace MyExtendableApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void snapInModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Allow user to select an assembly to load
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.Contains("CommonSnappableTypes"))
                    MessageBox.Show("CommonSnappableTypes has no snap-ins!");

                // LoadExternalModule tasks:
                // 1. Dynamically loads the selected assembly into memory
                // 2. Determines whether the assembly contains any types implementing IAppFunctionality
                // 3. Creates the type using late binding
                else if (!LoadExternalModule(dlg.FileName))
                    MessageBox.Show("Nothing implements IAppFunctionality");
            }
        }

        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;

            try
            {
                // Dynamically load the selected assembly
                theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }

            // Get all IAppFunctionality-compatible classes in assembly
            var theClassTypes = theSnapInAsm.GetTypes()
                      .Where(t => t.IsClass && t.GetInterface("IAppFunctionality") != null);

            // Create the object and call DoIt() method
            foreach (var t in theClassTypes)
            {
                foundSnapIn = true;

                // Use late binding to create the type
                IAppFunctionality itfApp =
                    (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);

                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(t.FullName);

                // Show company info
                DisplayCompanyData(t);
            }

            return foundSnapIn;
        }

        private void DisplayCompanyData(Type t)
        {
            var compInfo = t.GetCustomAttributes(false)
                .Where(ci => ci.GetType() == typeof(CompanyInfoAttribute));

            foreach (CompanyInfoAttribute c in compInfo)
            {
                MessageBox.Show(c.CompanyUrl,
                    string.Format($"More info about {c.CompanyName} can be found at"));
            }
        }
    }
}
