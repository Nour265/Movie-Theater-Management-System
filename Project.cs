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
    public partial class Login_Screen : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ToString());
        public Login_Screen()
        {
            InitializeComponent();


        }
      
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {


        }

         public void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string Useremail = txt_email.Text;
                string password = txt_password.Text;

                string query = "SELECT Password, Role FROM Person WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Email", Useremail);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedPassword = reader["Password"].ToString();
                        string role = reader["Role"].ToString();

                        if (storedPassword == password)
                        {

                            if (role == "Customer")
                            {
                                Employee_Menu customerForm = new Employee_Menu();
                                customerForm.Show();
                            
                            }
                            else if (role == "Employee")
                            {
                                Employee_Menu employeeForm = new Employee_Menu();
                                employeeForm.Show();
                            }
                            else if (role == "Admin")
                            {
                                Admin_Menu adminForm = new Admin_Menu();
                                adminForm.Show();
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Password!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email!");
                    }
                    reader.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred: " + ex.Message);
            }
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
