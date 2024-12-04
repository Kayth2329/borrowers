using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrowers
{
    public partial class BorrowBook : UserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source=CHARISSERAMIREZ\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True");

        public BorrowBook()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string bookTitle = txtTitle.Text.Trim();
            string connectionString = "Data Source=CHARISSERAMIREZ\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string query = "SELECT COUNT(*) FROM Borrowers WHERE Title = @Title";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", txtTitle.Text);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("The book is not Available");
                txtTitle.Clear();
                txtAuthor.Clear();
                txtDateborrow.Clear();
                lblDueDate.Text = string.Empty;
            }
            else
            {
                string insert = "INSERT INTO Borrowers (NAME, ADDRESS, STUDENT_NUMBER, TITLE, AUTHOR, DATE_BORROWED, DATE_DUE) VALUES ('" +
                txtNameborrower.Text + "', '" + txtAddress.Text + "', '" + txtStudentnumber.Text + "', '" + txtTitle.Text + "', '" + txtAuthor.Text + "', '" + txtDateborrow.Text + "', '" + lblDueDate.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, connection);
                cmd.ExecuteNonQuery();
                txtNameborrower.Clear();
                txtAddress.Clear();
                txtStudentnumber.Clear();
                txtTitle.Clear();
                txtAuthor.Clear();
                txtDateborrow.Clear();
                lblDueDate.Text = string.Empty;
                MessageBox.Show("Book Borrowed Succesfully");

            }


        }

        private void btnComputeDueDate_Click_1(object sender, EventArgs e)
                    {

        }

        private void btnComputeDueDate_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtDateborrow.Text, out DateTime borrowedDate))
            {
                DateTime dueDate = borrowedDate.AddDays(7);
                lblDueDate.Text = dueDate.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Invalid borrowed date input!");
            }
        }
    }
}
