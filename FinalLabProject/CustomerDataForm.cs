using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalLabProject
{
    public partial class CustomerDataForm : Form
    {
        public CustomerDataForm()
        {
            InitializeComponent();
            

        }



      
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text == string.Empty || txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty
                || txtTelephoneNumber.Text == string.Empty || txtCreditCardData.Text == string.Empty)
            {
                MessageBox.Show("Enter data in all the fields!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {


                SqlConnection conn = new SqlConnection(Form1.conString);


                string query = "SELECT * FROM CustomerInformation where CustomerID = @Cid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cid", txtCustomerID.Text);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    MessageBox.Show($"Customer with id = {txtCustomerID.Text} already exist!!!", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerID.Clear();
                }
                else
                {
                    conn.Close();
                    string query2 = "INSERT INTO  CustomerInformation VALUES (@CustomerID,@FirstName,@LastName,@TelephoneNumber,@CreditCardData)";

                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    cmd2.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text.Trim());
                    cmd2.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd2.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd2.Parameters.AddWithValue("@TelephoneNumber", txtTelephoneNumber.Text.Trim());
                    cmd2.Parameters.AddWithValue("@CreditCardData", txtCreditCardData.Text.Trim());

                    conn.Open();

                    int a = cmd2.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Data Inserted successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        BookingDetailForm.selectedCustomerID = Convert.ToInt32(txtCustomerID.Text);
                        BookingDetailForm bookingDetailForm = new BookingDetailForm();
                        bookingDetailForm.Show();
                        this.Hide();
                        // bookingDetailForm.SetCustomerID(txtCustomerID.Text);
                       
                      

                        ResetControls();

                    }
                    else
                    {
                        MessageBox.Show("Data insertion Failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.Close();

                }
                
            }
            
        }

        private void ResetControls()
        {
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTelephoneNumber.Clear();
            txtCreditCardData.Clear();
        }
    }
}
