using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLabProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string conString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        
        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string query = "SELECT RentalID, AccommodationType, Location FROM VacationRentalData";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Bind the DataTable to the DataGridView
                        dgvRentals.DataSource = dataTable;
                    }
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string query = "SELECT RentalID, AccommodationType, Location FROM VacationRentalData WHERE AccommodationType LIKE @name + '%'";
                SqlDataAdapter searchRental = new SqlDataAdapter(query, connection);
                searchRental.SelectCommand.Parameters.AddWithValue("@name", txtSearch.Text.Trim());

                DataTable rentals = new DataTable();
                searchRental.Fill(rentals);

                if (rentals.Rows.Count > 0)
                {
                    dgvRentals.DataSource = rentals;
                    txtSearch.Clear();
                    txtSearch.Focus();
                    
                   
                }
                else
                {
                    MessageBox.Show("Rental you searched for does not exist!!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

      
        private void dgvRentals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            


            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow selectedRow = dgvRentals.Rows[e.RowIndex];

              
                int selectedRentalID = Convert.ToInt32(selectedRow.Cells["RentalID"].Value);


                RentalDetailsForm detailsForm = new RentalDetailsForm(selectedRentalID);
                detailsForm.Show();
                this.Hide();


                //send selected rental id to BookingDetailForm
                BookingDetailForm.selectedRentalID = selectedRentalID;


            }
          
        }


       
    }
}
