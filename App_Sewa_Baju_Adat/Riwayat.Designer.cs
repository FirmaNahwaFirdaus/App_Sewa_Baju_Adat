namespace App_Sewa_Baju_Adat
{
    partial class Riwayat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Riwayat));
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.dgvRiwayat = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.keluar = new System.Windows.Forms.Button();
            this.kembali = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.RosyBrown;
            this.btnHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Location = new System.Drawing.Point(163, 388);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 15;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(76, 388);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.RosyBrown;
            this.btnCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(324, 108);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(48, 23);
            this.btnCari.TabIndex = 13;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Cari Riwayat";
            // 
            // txtCari
            // 
            this.txtCari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCari.Location = new System.Drawing.Point(144, 110);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(165, 20);
            this.txtCari.TabIndex = 11;
            // 
            // dgvRiwayat
            // 
            this.dgvRiwayat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiwayat.Location = new System.Drawing.Point(75, 148);
            this.dgvRiwayat.Name = "dgvRiwayat";
            this.dgvRiwayat.Size = new System.Drawing.Size(653, 234);
            this.dgvRiwayat.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "RIWAYAT DATA TRANSAKSI SEWA BAJU ADAT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(94, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 54);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // keluar
            // 
            this.keluar.BackColor = System.Drawing.Color.RosyBrown;
            this.keluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keluar.Location = new System.Drawing.Point(653, 388);
            this.keluar.Name = "keluar";
            this.keluar.Size = new System.Drawing.Size(75, 23);
            this.keluar.TabIndex = 16;
            this.keluar.Text = "Keluar";
            this.keluar.UseVisualStyleBackColor = false;
            this.keluar.Click += new System.EventHandler(this.keluar_Click);
            // 
            // kembali
            // 
            this.kembali.BackColor = System.Drawing.Color.RosyBrown;
            this.kembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kembali.Location = new System.Drawing.Point(572, 388);
            this.kembali.Name = "kembali";
            this.kembali.Size = new System.Drawing.Size(75, 23);
            this.kembali.TabIndex = 17;
            this.kembali.Text = "Kembali";
            this.kembali.UseVisualStyleBackColor = false;
            this.kembali.Click += new System.EventHandler(this.kembali_Click);
            // 
            // Riwayat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kembali);
            this.Controls.Add(this.keluar);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.dgvRiwayat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Riwayat";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.DataGridView dgvRiwayat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button keluar;
        private System.Windows.Forms.Button kembali;
    }
}