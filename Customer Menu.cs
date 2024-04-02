using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Movie_Theater_Management
{
    public partial class Employee_Menu : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ToString());

        public Employee_Menu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e) 
        {
            try
            {
                if(con.State!=ConnectionState.Open)
                    con.Open();
                string customerName = "";
                string email = Login_Screen.txt_email.Text;
                string query = "Select Name From Person WHERE Email LIKE @email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.Read())
                {
                    customerName = rdr.GetValue(0).ToString();
                }

                label1.Text = "Welcome, " + customerName + "!";
                
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred: " + ex.Message);
            }

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Movie_Booking bookingForm = new Movie_Booking();
            bookingForm.Show();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_Account accountForm = new Customer_Account();
            accountForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Movie_Booking bookingForm = new Movie_Booking();
            bookingForm.Show();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_Account accountForm = new Customer_Account();
            accountForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_editmovie_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Movies Editform = new Edit_Movies();
            Editform.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Screen back = new Login_Screen();
            back.Show();
        }
    }
}
