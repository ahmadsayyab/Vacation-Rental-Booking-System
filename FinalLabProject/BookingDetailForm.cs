using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLabProject
{

    public partial class BookingDetailForm : Form
    {

        //property to get selectedCustomerID
        public static int selectedCustomerID { get; set; }
        

        //property to get rentalId
        public static int selectedRentalID { get; set; }
     
        public BookingDetailForm()
        {
            InitializeComponent();
          
            try
            {
                DisplayAvailableDates(selectedRentalID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in DisplayAvailableDates: {ex.Message}");
            }
        }


        //method to calculate total Cost of stay
        private void CalculateTotalCost()
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            decimal costPerDay = GetCostPerDay(selectedRentalID);

            int numberOfDays = (int)(endDate - startDate).TotalDays+1;

            decimal totalCost = costPerDay * numberOfDays;

            txtTotalCost.Text = totalCost.ToString();
        }


        private decimal GetCostPerDay(int rentalID)
        {

            decimal costPerDay = 0;
            using (SqlConnection connection = new SqlConnection(Form1.conString))
            {
                connection.Open();

                string query = "SELECT CostPerDay FROM VacationRentalData WHERE RentalID = @rentalID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@rentalID", rentalID);


                    object result = command.ExecuteScalar();


                    if (result != null)
                    {

                        costPerDay = Convert.ToDecimal(result);


                    }
                    
                }
            }
            return costPerDay;
        }

        private void BookingDetailForm_Load(object sender, EventArgs e)
        {

            //CalculateTotalCost();
            // DisplayAvailableDates(selectedRentalID);


        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            CalculateTotalCost();

            using (SqlConnection conn = new SqlConnection(Form1.conString))
            {
                if (txtBookingID.Text == string.Empty)
                {
                    MessageBox.Show("Enter Booking Id!!", "Missing Id", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Check if the selected dates are already booked
                string overlapCheckQuery = @"
            SELECT * 
            FROM BookingsData 
            WHERE RentalID = @RentalID
            AND (
                (@StartDate BETWEEN StartDate AND EndDate)
                OR (@EndDate BETWEEN StartDate AND EndDate)
                OR (StartDate BETWEEN @StartDate AND @EndDate)
            );
        ";

                conn.Open(); // Open the connection for the overlap check
                using (SqlCommand overlapCheckCmd = new SqlCommand(overlapCheckQuery, conn))
                {
                    overlapCheckCmd.Parameters.AddWithValue("@RentalID", selectedRentalID);
                    overlapCheckCmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                    overlapCheckCmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);

                    using (SqlDataReader overlapReader = overlapCheckCmd.ExecuteReader())
                    {
                        if (overlapReader.HasRows)
                        {
                            MessageBox.Show("Selected dates are not available. Rental is already booked for this period.", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTotalCost.Clear();
                            return;
                        }
                    }
                }

                // Check for an existing booking with the provided BookingID
                string query = "SELECT * FROM BookingsData where BookingID = @Bid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Bid", txtBookingID.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show($"Booking with id = {txtBookingID.Text} already exists!!!", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtBookingID.Clear();
                            txtBookingID.Focus();
                            return;
                        }
                    }
                }

                // If no overlapping bookings and no existing booking with the same ID, proceed with the booking confirmation logic
                string insertBookingQuery = "INSERT INTO BookingsData VALUES (@BookingID,@RentalID,@CustomerID,@StartDate,@EndDate,@TotalCost)";

                using (SqlCommand insertBookingCmd = new SqlCommand(insertBookingQuery, conn))
                {
                    insertBookingCmd.Parameters.AddWithValue("@BookingID", txtBookingID.Text.Trim());
                    insertBookingCmd.Parameters.AddWithValue("@RentalID", selectedRentalID);
                    insertBookingCmd.Parameters.AddWithValue("@CustomerID", selectedCustomerID);
                    insertBookingCmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                    insertBookingCmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                    insertBookingCmd.Parameters.AddWithValue("@TotalCost", txtTotalCost.Text);

                   // conn.Open(); // Open the connection for the final insert
                    int a = insertBookingCmd.ExecuteNonQuery();

                    if (a > 0)
                    {
                        MessageBox.Show("Booking Confirmed!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Booking Confirmation Failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //conn.Close();
                }
            }
        }



        //load existing dates from database
        private void DisplayAvailableDates(int rentalID)
        {
           

            using (SqlConnection con = new SqlConnection(Form1.conString))
            using (SqlCommand cmd = new SqlCommand("SELECT AvailableFromDate, AvailableUntilDate FROM VacationRentalData WHERE RentalID = @rentalID", con))
            {
                con.Open();
               

                cmd.Parameters.AddWithValue("@rentalID", rentalID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Retrieve the start and end dates from the database
                        DateTime startDate = reader.GetDateTime(reader.GetOrdinal("AvailableFromDate"));
                        DateTime endDate = reader.GetDateTime(reader.GetOrdinal("AvailableUntilDate"));

                        // Display the dates in the respective DateTimePicker controls
                        dtpStartDate.Value = startDate;
                        dtpEndDate.Value = endDate;

                        
                    }
                    else
                    {
                        
                        MessageBox.Show("No available dates found for the selected RentalID.");
                    }
                }
            }
        }

        private void btnViewReceipt_Click(object sender, EventArgs e)
        {
            BookingReceiptForm.BookingID = Convert.ToInt32(txtBookingID.Text);
            BookingReceiptForm bookingReceiptForm = new BookingReceiptForm();
            bookingReceiptForm.Show();
            this.Hide();
        }

    }
}
