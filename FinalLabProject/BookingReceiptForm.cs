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

namespace FinalLabProject
{
    public partial class BookingReceiptForm : Form
    {
        public static int BookingID { get; set; }
        public BookingReceiptForm()
        {
            InitializeComponent();
        }
        private void BookingReceiptForm_Load(object sender, EventArgs e)
        {
            rtxBookingReceipt.Clear();

            // Set the center alignment
            rtxBookingReceipt.SelectionAlignment = HorizontalAlignment.Center;

            

            // Append the title to the rich text box with specific formatting
            //rtxBookingReceipt.AppendText("**********************************\n");
            rtxBookingReceipt.SelectionFont = new Font(rtxBookingReceipt.Font.FontFamily, 24, FontStyle.Bold);
            rtxBookingReceipt.AppendText("        Booking Receipt            \n");
            //rtxBookingReceipt.AppendText("**********************************\n");

            using (SqlConnection conn = new SqlConnection(Form1.conString))
            {
                conn.Open();

                string query = @"
            SELECT
                B.BookingID,
                C.CustomerID,
                C.FirstName,
                C.LastName,
                C.TelephoneNumber,
                VR.AccommodationType,
                VR.Location,
                B.StartDate,
                B.EndDate,
                B.TotalCost
            FROM
                BookingsData B
            JOIN
                VacationRentalData VR ON B.RentalID = VR.RentalID
            JOIN
                CustomerInformation C ON B.CustomerID = C.CustomerID
            WHERE
                B.BookingID = @BookingID;
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", BookingID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        
                        // Append the details to the rich text box with specific formatting
                        rtxBookingReceipt.AppendText($"\n\n\n\nBooking ID\t\t: {reader["BookingID"]}\n\n");
                        rtxBookingReceipt.AppendText($"Customer ID\t\t: {reader["CustomerID"]}\n\n");
                        rtxBookingReceipt.AppendText($" First Name \t\t: {reader["FirstName"]}\n\n");
                        rtxBookingReceipt.AppendText($" Last Name  \t\t: {reader["LastName"]}\n\n");
                        rtxBookingReceipt.AppendText($"Telephone Number\t\t\t: {reader["TelephoneNumber"]}\n\n");
                        rtxBookingReceipt.AppendText($"Accommodation Type\t: {reader["AccommodationType"]}\n\n");
                        rtxBookingReceipt.AppendText($"  Location   \t\t: {reader["Location"]}\n\n");
                        rtxBookingReceipt.AppendText($"  Start Date \t\t: {((DateTime)reader["StartDate"]).ToShortDateString()}\n\n");
                        rtxBookingReceipt.AppendText($"  End Date   \t\t: {((DateTime)reader["EndDate"]).ToShortDateString()}\n\n");
                        rtxBookingReceipt.AppendText($"  Total Cost \t\t: {Convert.ToDecimal(reader["TotalCost"]):C}\n\n");
                    }
                }
            }
        }


    }

}
