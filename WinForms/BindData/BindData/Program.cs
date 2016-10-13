using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private BindingSource bindingSource1 = new BindingSource();
    private SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter();
    private Button reloadButton = new Button();
    private Button submitButton = new Button();
    private ComboBox selectCombo = new ComboBox();

    [STAThread()]
    public static void Main()
    {
        Form1 myForm = new Form1();
        myForm.Size = new Size(600, 300);

        myForm.selectCombo.DataSource = myForm.ListTables();

        Application.Run(myForm);
    }



    // Initialize the form.
    public Form1()
    {
        dataGridView1.Dock = DockStyle.Fill;

        reloadButton.Text = "Reload";
        submitButton.Text = "Submit";
        reloadButton.Click += new EventHandler(reloadButton_Click);
        submitButton.Click += new EventHandler(submitButton_Click);
        selectCombo.SelectedValueChanged += new EventHandler(SelectCombo_SelectedValueChanged);

        FlowLayoutPanel panel = new FlowLayoutPanel();
        panel.Dock = DockStyle.Top;
        panel.AutoSize = true;
        panel.Controls.AddRange(new Control[] { reloadButton, submitButton, selectCombo });

        Controls.AddRange(new Control[] { dataGridView1, panel });
        Load += new EventHandler(Form1_Load);
        Text = "SQLite + DataGridView";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Bind the DataGridView to the BindingSource
        // and load the data from the database.
        dataGridView1.DataSource = bindingSource1;
        GetData("select * from COMPANY");
    }

    private void reloadButton_Click(object sender, EventArgs e)
    {
        // Reload the data from the database.
        GetData(dataAdapter.SelectCommand.CommandText);
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        try
        {
            // Update the database with the user's changes.
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void SelectCombo_SelectedValueChanged(object sender, EventArgs e)
    {
        string chosenTable = selectCombo.SelectedValue.ToString();
        GetData("select * from " + chosenTable);
    }

    private void GetData(string selectCommand)
    {
        string connectionString = "Data Source=db2.db";

        // Create a new data adapter based on the specified query.
        dataAdapter = new SQLiteDataAdapter(selectCommand, connectionString);

        // Create a command builder to generate SQL update, insert, and
        // delete commands based on selectCommand. These are used to
        // update the database.
        SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(dataAdapter);

        // Populate a new data table and bind it to the BindingSource.
        DataTable table = new DataTable();
        dataAdapter.Fill(table);
        bindingSource1.DataSource = table;

        // Resize the DataGridView columns to fit the newly loaded content.
        dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
    }

    private List<string> ListTables()
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=db2.db");
        con.Open();
        Console.WriteLine("Connection is " + con.State.ToString());
        List<string> tables = new List<string>();
        DataTable dt = con.GetSchema("Tables");
        foreach (DataRow row in dt.Rows)
        {
            string tablename = (string)row[2];
            tables.Add(tablename);
        }
        con.Close();
        Console.WriteLine("Connection is " + con.State.ToString());
        return tables;
    }



}