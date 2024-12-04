using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrowers
{
    public partial class List : UserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source=CHARISSERAMIREZ\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True");

        public List()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=CHARISSERAMIREZ\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True");


        private void List_Load(object sender, EventArgs e)
        {
        }


        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchValue = txtNamesearch.Text.Trim();
            foreach (DataGridViewRow row in dgvListborrowers.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Equals(searchValue, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=CHARISSERAMIREZ\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Borrowers ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvListborrowers.DataSource = dt;
            }

        }
    }
}
