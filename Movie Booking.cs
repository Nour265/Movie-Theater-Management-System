using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_Theater_Management
{

    public partial class Movie_Booking : System.Windows.Forms.Form
    {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ToString());
            public Movie_Booking()
        {
            InitializeComponent();
            txt_searchname.TextChanged += new EventHandler(txt_searchname_TextChanged);
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
        }
        private int _selectedMovieId = -1;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                // Try to parse the movie ID safely
                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), out int movieId))
                {
                    _selectedMovieId = movieId; // Assuming the movie ID is in the first column
                    DisplayAvailableSeats(_selectedMovieId);
                }
                else
                {
                    MessageBox.Show("Please select a valid movie.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a movie.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           }

            private void LoadMovies(string searchName = "")
            {
                try
                {
                    string query;
                    if (comboBox1.SelectedItem != null)
                    {
                        if (comboBox1.SelectedItem.ToString() == "All" && string.IsNullOrEmpty(searchName))
                        {
                            query = "SELECT Id, Name, Description, LeadActors, Duration FROM Movie";
                        }
                        else
                        {
                            string selectedGenre = comboBox1.SelectedItem.ToString();
                            query = "SELECT m.Id, m.Name, m.Description, m.LeadActors, m.Duration " +
                                    "FROM Movie m " +
                                    "INNER JOIN BelongsTo b ON m.Id = b.MID " +
                                    "INNER JOIN Genre g ON b.GID = g.Id ";

                            if (!string.IsNullOrEmpty(searchName))
                            {
                                // Add a WHERE clause to filter by movie name
                                query += $"WHERE m.Name LIKE '%{searchName}%' ";

                                // Include genre filter if a specific genre is selected
                                if (comboBox1.SelectedItem.ToString() != "All")
                                {
                                    query += $"AND g.Type = '{selectedGenre}' ";
                                }
                            }
                            else if (comboBox1.SelectedItem.ToString() != "All")
                            {
                                // Filter only by genre
                                query += $"WHERE g.Type = '{selectedGenre}' ";
                            }
                        }
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        var datatable = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(datatable);
                        con.Close();
                        da.Dispose();

                        dataGridView1.DataSource = datatable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred: " + ex.Message);
                }
            }
            public void TestBookButtonOnClickFunction(object sender, DataGridViewCellEventArgs e)
            {
                // Get Movie Id From click
            }

            private void Form5_Load(object sender, EventArgs e)
            {
                try
                {
                    comboBox1.Items.Clear();

                    // Fetch genre types from the Genre table
                    string query = "SELECT Type FROM Genre";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    comboBox1.Items.Add("All");
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["Type"].ToString());
                    }

                    con.Close();

                    // Select the first genre type by default, if available
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }

                    // Load all movies initially
                    LoadMovies();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred: " + ex.Message);
                }
            }

            private void btn_load_Click(object sender, EventArgs e)
            {

            }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Reload movies based on the selected genre type
                LoadMovies();
            }

            private void LoadMovies()
            {
                try
                {
                    string query;
                    if (comboBox1.SelectedItem != null)
                    {
                        if (comboBox1.SelectedItem == "All")
                        {
                            // Load all movies if no genre is selected
                            query = "SELECT Id, Name, Description, LeadActors, Duration FROM Movie";
                        }
                        else
                        {
                            string selectedGenre = comboBox1.SelectedItem.ToString();
                            // Filter movies based on the selected genre type
                            query = "SELECT m.Id, m.Name, m.Description, m.LeadActors, m.Duration " +
                                    "FROM Movie m " +
                                    "INNER JOIN BelongsTo b ON m.Id = b.MID " +
                                    "INNER JOIN Genre g ON b.GID = g.Id " +
                                    $"WHERE g.Type = '{selectedGenre}'";
                        }
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        var datatable = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(datatable);
                        con.Close();
                        da.Dispose();

                        dataGridView1.DataSource = datatable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred: " + ex.Message);
                }
          
        }

            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }



            private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
            {
                // Reload movies based on the selected genre or all movies
                LoadMovies();
            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

            private void txt_searchname_TextChanged(object sender, EventArgs e)
            {
                LoadMovies(txt_searchname.Text.Trim());
            }

            private void button1_Click(object sender, EventArgs e)
            {
                this.Hide();
                Employee_Menu back = new Employee_Menu();
                back.Show();
            }

            private void dv_Seat_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dv_Seat.Rows.Count > e.RowIndex)
            {
                    // Assuming you have a button column for booking the seat
                    int seatId = Convert.ToInt32(dv_Seat.Rows[e.RowIndex].Cells["id"].Value);
                    DateTime st = Convert.ToDateTime(dv_Seat.Rows[e.RowIndex].Cells["startingtime"].Value);
                    DateTime et= Convert.ToDateTime(dv_Seat.Rows[e.RowIndex].Cells["endingtime"].Value);
                    BookSeat(seatId, _selectedMovieId, st, et);

                    // Refresh the seat grid to show only available seats
                    DisplayAvailableSeats(_selectedMovieId);
            }

        }
            private void BookSeat(int seatId, int movieid, DateTime st, DateTime et)
            {
            string query = "Insert into ToWatch values (@sid, @mid, @st, @et)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@sid", seatId);
                cmd.Parameters.AddWithValue("@mid", movieid);
                cmd.Parameters.AddWithValue("@st", st);
                cmd.Parameters.AddWithValue("@et", et);

                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if the update was successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Seat booked successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to book the seat. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while booking the seat: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
        }
 
        private void DisplayAvailableSeats(int movieId)
        {
            DataTable datatable = new DataTable();
            string query = "SELECT seat.id, takesplacein.number as 'Auditorium Number' , takesplacein.startingtime, takesplacein.endingtime, seat.#Row, seat.#Column, seat.Price FROM takesplacein INNER JOIN seat ON takesplacein.number = seat.number WHERE takesplacein.id = @movieid and seat.id NOT IN (SELECT towatch.sid FROM towatch INNER JOIN takesplacein ON towatch.mid = takesplacein.id WHERE towatch.startingtime = takesplacein.startingtime and towatch.EndingTime= TakesPlaceIn.EndingTime);";
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
              
                
                    cmd.Parameters.AddWithValue("@movieid", movieId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(datatable);
                    dv_Seat.DataSource = datatable;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while displaying available seats: " + ex.Message);
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
}
