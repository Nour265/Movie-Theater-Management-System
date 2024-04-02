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

namespace Movie_Theater_Management
{
    public partial class Customer_Account : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ToString());
        
        public Customer_Account()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Customer_Account_Load(object sender, EventArgs e)
        {
         try
            {
                string email = Login_Screen.txt_email.Text;
                string query = "Select name, email, phone, address, age, gender FROM Person WHERE Email LIKE @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@Email", "%" + email + "%");


                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {

                        DataTable dt_info = new DataTable();
                        adapter.Fill(dt_info);


                        dataGridView1.DataSource = dt_info;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has Occurred: " + ex.Message);
            }
            InitializeComboBoxOptions();
        }

        private void InitializeComboBoxOptions()
        {
            
            comboBox1.Items.Clear(); 
            comboBox1.Items.Add("Name");
            comboBox1.Items.Add("Email");
            comboBox1.Items.Add("Age");
            comboBox1.Items.Add("Gender");
            comboBox1.Items.Add("Phone");
            comboBox1.Items.Add("Address");
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a field to edit.");
                return;
            }
            string selectedField = comboBox1.SelectedItem.ToString();
            
            string newValue = textBox1.Text;
            string email = Login_Screen.txt_email.Text;

            if (string.IsNullOrWhiteSpace(selectedField))
            {
                MessageBox.Show("Please select the field to edit.");
                return;
            }
            if (string.IsNullOrWhiteSpace(newValue))
            {
                MessageBox.Show("Please enter the new value.");
                return;
            }
           


            try
            {
                UpdateCustomerInfo(selectedField, newValue, email);
                MessageBox.Show("Information updated successfully.");

                // Optional: refresh the data grid view to show new data
                // You would write another method to reload the data into the dataGridView1,
                // similar to what you've done in the Customer_Account_Load method.
                LoadCustomerData();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occurred while updating information: " + ex.Message);
            }
        }

        private void UpdateCustomerInfo(string selectedField, string newValue, string email)
        {
            // Convert the user-friendly field name to the actual database column name
            var fieldMapping = new Dictionary<string, string>
    {
        { "Name", "name" },
        { "Email", "email" },
        { "Age", "age" },
        { "Gender", "gender" },
        { "Phone", "phone" },
        { "Address", "address" }
    };

            if (!fieldMapping.TryGetValue(selectedField, out string dbFieldName))
            {
                MessageBox.Show("Invalid field selection.");
                return;
            }

            // SQL UPDATE statement
            string updateQuery = $"UPDATE Person SET {dbFieldName} = @NewValue WHERE Email = @Email";

            try
            {
                // Open the connection if it's not already
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                // Create a SqlCommand to execute the update
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    // Use parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@NewValue", newValue);
                    cmd.Parameters.AddWithValue("@Email", email);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Information updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No information was updated. Please check the provided details.");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-related errors
                MessageBox.Show("A database error has occurred: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other errors
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed when done
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadCustomerData()
        {
            try
            {
                string email = Login_Screen.txt_email.Text;
                string query = "Select name, email, phone, address, age, gender FROM Person WHERE Email LIKE @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", "%" + email + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt_info = new DataTable();
                        adapter.Fill(dt_info);
                        dataGridView1.DataSource = dt_info;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has Occurred: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_Menu back = new Employee_Menu();
            back.Show();
        }
    }
}

