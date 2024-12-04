using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrowers
{
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
        }

        Bitmap bmp;

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=CHARISSERAMIREZ\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                DateTime currentDate = DateTime.Today;
                string query = "SELECT * FROM Borrowers WHERE ReturnDate < @CurrentDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CurrentDate", currentDate);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvReport.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int height = dgvReport.Height;
            dgvReport.Height = dgvReport.RowCount * dgvReport.RowTemplate.Height * 2;
            bmp = new Bitmap(dgvReport.Width, dgvReport.Height);
            dgvReport.DrawToBitmap(bmp, new Rectangle(0, 0, dgvReport.Width, dgvReport.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dgvReport.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
