using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLabProject
{
    public partial class RentalDetailsForm : Form
    {
        private int SelectedRentalID;


        public RentalDetailsForm(int selectedRentalID)
        {
            InitializeComponent();
            this.SelectedRentalID = selectedRentalID;


            BindGridView();
        }

        public void BindGridView()
        {
            string query = "SELECT * FROM VacationRentalData WHERE RentalID = @selectedRentalID";
            using (SqlConnection con = new SqlConnection(Form1.conString))

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@selectedRentalID", SelectedRentalID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                      
                        if (dataTable.Columns.Contains("Picture"))
                        {
                            dataTable.Columns.Remove("Picture");
                        }

                       
                        dgvRentalDetail.DataSource = dataTable;
                    }
                }

                string query1 = "SELECT Picture FROM VacationRentalData WHERE RentalID = @selectedRentalID";
                using (SqlConnection con2 = new SqlConnection(Form1.conString))
                using (SqlCommand cmd2 = new SqlCommand(query1, con2))
                {
                    con2.Open();
                    cmd2.Parameters.AddWithValue("@selectedRentalID", SelectedRentalID);

                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        if (reader2.Read())
                        {
                            object imageData = reader2["Picture"];
                            if (imageData != DBNull.Value && imageData != null)
                            {
                                pictureBox1.Image = ByteArrayToImage((byte[])imageData);
                            }
                            else
                            {
                                pictureBox1.Image = null;
                            }
                        }
                    }
                }
            }
        }



        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                try
                {
                    Image returnImage = Image.FromStream(ms);
                    return returnImage;
                }
                catch (ArgumentException)
                {
                    
                    return null;
                }
            }
        }



        private void btnRentalList_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnBoolRental_Click(object sender, EventArgs e)
        {
            CustomerDataForm customerDataForm = new CustomerDataForm();
            customerDataForm.Show();
            this.Hide();
        }
    }
}