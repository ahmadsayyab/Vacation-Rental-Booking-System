namespace FinalLabProject
{
    partial class RentalDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvRentalDetail = new System.Windows.Forms.DataGridView();
            this.btnRentalList = new System.Windows.Forms.Button();
            this.btnBoolRental = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(237, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rental Detail Information";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 443);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 17);
            this.panel2.TabIndex = 1;
            // 
            // dgvRentalDetail
            // 
            this.dgvRentalDetail.AllowUserToAddRows = false;
            this.dgvRentalDetail.AllowUserToDeleteRows = false;
            this.dgvRentalDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentalDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalDetail.Location = new System.Drawing.Point(32, 82);
            this.dgvRentalDetail.Name = "dgvRentalDetail";
            this.dgvRentalDetail.ReadOnly = true;
            this.dgvRentalDetail.Size = new System.Drawing.Size(483, 252);
            this.dgvRentalDetail.TabIndex = 2;
            // 
            // btnRentalList
            // 
            this.btnRentalList.BackColor = System.Drawing.Color.Green;
            this.btnRentalList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentalList.ForeColor = System.Drawing.Color.White;
            this.btnRentalList.Location = new System.Drawing.Point(88, 352);
            this.btnRentalList.Name = "btnRentalList";
            this.btnRentalList.Size = new System.Drawing.Size(152, 38);
            this.btnRentalList.TabIndex = 3;
            this.btnRentalList.Text = "Back to Rental List";
            this.btnRentalList.UseVisualStyleBackColor = false;
            this.btnRentalList.Click += new System.EventHandler(this.btnRentalList_Click);
            // 
            // btnBoolRental
            // 
            this.btnBoolRental.BackColor = System.Drawing.Color.Green;
            this.btnBoolRental.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoolRental.ForeColor = System.Drawing.Color.White;
            this.btnBoolRental.Location = new System.Drawing.Point(267, 352);
            this.btnBoolRental.Name = "btnBoolRental";
            this.btnBoolRental.Size = new System.Drawing.Size(152, 38);
            this.btnBoolRental.TabIndex = 4;
            this.btnBoolRental.Text = "Book Rental";
            this.btnBoolRental.UseVisualStyleBackColor = false;
            this.btnBoolRental.Click += new System.EventHandler(this.btnBoolRental_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(531, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 252);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // RentalDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 460);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBoolRental);
            this.Controls.Add(this.btnRentalList);
            this.Controls.Add(this.dgvRentalDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RentalDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentalDetailsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRentalDetail;
        private System.Windows.Forms.Button btnRentalList;
        private System.Windows.Forms.Button btnBoolRental;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}