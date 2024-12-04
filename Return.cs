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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Borrowers
{
    public partial class Return : UserControl
    {
        public Return()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=CHARISSERAMIREZ\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string query = "SELECT COUNT(*) FROM Borrowers WHERE Title = @Title";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", txtTitlereturn.Text);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                string delete = "DELETE FROM Borrowers WHERE Title = @Title";
                SqlCommand deleteCommand = new SqlCommand(delete, connection);
                deleteCommand.Parameters.AddWithValue("@Title", txtTitlereturn.Text);
                deleteCommand.ExecuteNonQuery();

                MessageBox.Show("Record deleted successfully!");
                txtNameborrowerreturn.Clear();
                txtDateborrowreturn.Clear();
                txtTitlereturn.Clear();
                txtAuthorreturn.Clear();
            }
            else
            {
                MessageBox.Show("Record not found.");
            }
        }
    }
}
