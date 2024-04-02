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
    public partial class Edit_Movies : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ToString());
        public Edit_Movies()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Movie";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable movie = new DataTable();
                adapter.Fill(movie);
                dv_movie.DataSource = movie;
                dv_movie.AutoGenerateColumns = true;
                dv_movie.AllowUserToAddRows = true;
                dv_movie.AllowUserToDeleteRows = true;
                dv_movie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dv_movie.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            dv_movie.SelectionChanged += Dv_movie_SelectionChanged;
        }

        private void Dv_movie_SelectionChanged(object sender, EventArgs e)
        {
            if (dv_movie.SelectedRows.Count > 0)
            {
                PopulateTextBoxesFromSelectedRow();
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dv_movie.SelectedRows.Count > 0)
            {
                PopulateTextBoxesFromSelectedRow();
            }
            else
            {
                MessageBox.Show("Please select a movie to edit.");
            }
        }
        private void PopulateTextBoxesFromSelectedRow()
        {
            DataGridViewRow selectedRow = dv_movie.SelectedRows[0];

            if (!selectedRow.IsNewRow)
            {
                string id = selectedRow.Cells["ID"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();
                string leadActors = selectedRow.Cells["LeadActors"].Value.ToString();
                string duration = selectedRow.Cells["Duration"].Value.ToString();

                txt_ID.Text = id;
                txt_Name.Text = name;
                txt_desc.Text = description;
                txt_Leadactors.Text = leadActors;
                txt_Duration.Text = duration;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        
        private void RefreshDataGridView()
        {
            string selectQuery = "SELECT * FROM Movie";
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dv_movie.DataSource = dt;
        }
       

        private void Add_movie_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add this movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Movie WHERE ID = @ID", con);
                    cmdCheck.Parameters.AddWithValue("@ID", txt_ID.Text);
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("ID already exists. Please choose a different ID.");
                        return;
                    }
                    string query = "INSERT INTO Movie (ID, Name, Description, LeadActors, Duration) VALUES (@ID, @Name, @Description, @LeadActors, @Duration)";
                    SqlCommand cmdInsert = new SqlCommand(query, con);
                    cmdInsert.Parameters.AddWithValue("@ID", txt_ID.Text);
                    cmdInsert.Parameters.AddWithValue("@Name", (string.IsNullOrEmpty(txt_Name.Text) ? DBNull.Value : (object)txt_Name.Text));
                    cmdInsert.Parameters.AddWithValue("@Description", (string.IsNullOrEmpty(txt_desc.Text) ? DBNull.Value : (object)txt_desc.Text));
                    cmdInsert.Parameters.AddWithValue("@LeadActors", (string.IsNullOrEmpty(txt_Leadactors.Text) ? DBNull.Value : (object)txt_Leadactors.Text));
                    cmdInsert.Parameters.AddWithValue("@Duration", (string.IsNullOrEmpty(txt_Duration.Text) ? DBNull.Value : (object)txt_Duration.Text));

                    cmdInsert.ExecuteNonQuery();
                    string selectQuery = "SELECT * FROM Movie";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dv_movie.DataSource = dt;

                    MessageBox.Show("Data inserted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error has occurred: " + ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }

            }
        }

        private void edit_btn_Click_1(object sender, EventArgs e)
        {
            if (dv_movie.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movie to edit.");
                return;
            }
            DataGridViewRow selectedRow = dv_movie.SelectedRows[0];
            if (selectedRow.IsNewRow || selectedRow.Cells["ID"].Value == null)
            {
                MessageBox.Show("Please select a valid movie to edit.");
                return;
            }

            string Id = selectedRow.Cells["ID"].Value.ToString();

            try
            {
                con.Open();
                string updateQuery = "UPDATE Movie SET Name = @Name, Description = @Description, LeadActors = @LeadActors, Duration = @Duration WHERE ID = @ID";
                SqlCommand cmdUpdate = new SqlCommand(updateQuery, con);
                cmdUpdate.Parameters.AddWithValue("@Name", txt_Name.Text);
                cmdUpdate.Parameters.AddWithValue("@Description", txt_desc.Text);
                cmdUpdate.Parameters.AddWithValue("@LeadActors", txt_Leadactors.Text);
                cmdUpdate.Parameters.AddWithValue("@Duration", txt_Duration.Text);
                cmdUpdate.Parameters.AddWithValue("@ID", Id);

                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Movie updated successfully.");
                }
                else
                {
                    MessageBox.Show("No movie updated.");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            RefreshDataGridView();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (dv_movie.SelectedRows.Count == 0 || dv_movie.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Please select a movie to delete.");
                return;
            }

            DataGridViewRow selectedRow = dv_movie.SelectedRows[0];

            string id = selectedRow.Cells["ID"].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    DeleteMovieGenreRelationships(txt_ID.Text);
                    string deleteQuery = "DELETE FROM Movie WHERE ID = @ID";
                    SqlCommand cmdDelete = new SqlCommand(deleteQuery, con);
                    cmdDelete.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = cmdDelete.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie deleted successfully.");
                        RefreshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("No movie deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_Menu back = new Employee_Menu();
            back.Show();
        }
        private void DeleteMovieGenreRelationships(string movieId)
        {
            string deleteQuery = "DELETE FROM BelongsTo WHERE MID = @MovieId";

            try
            {
                
                {
                    
                    using (SqlCommand command = new SqlCommand(deleteQuery, con))
                    {
                        
                        command.Parameters.AddWithValue("@MovieId", movieId);
                        
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the movie-genre relationships: " + ex.Message);
            }
        }

        private void genrechecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                this.genrechecklist.SelectedIndexChanged += new System.EventHandler(this.genrechecklist_SelectedIndexChanged);
            }
        }
    }
}
                

