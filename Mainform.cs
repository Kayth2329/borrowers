using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrowers
{
    
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        public string name;

        private void button1_Click(object sender, EventArgs e)
        {
            borrowBook1.Visible = true;
            list1.Visible = false;
            return1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            borrowBook1.Visible = false;
            list1.Visible = true;
            return1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            borrowBook1.Visible = false;
            list1.Visible = false;
            return1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            borrowBook1.Visible = false;
            list1.Visible = false;
            return1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
            list1.Visible = false;
            return1.Visible = false;
        }

        private void report1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
