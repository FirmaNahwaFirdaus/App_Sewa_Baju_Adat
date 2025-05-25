namespace App_Sewa_Baju_Adat.Views
{
    partial class LaporanHarian
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartLaporan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLaporan
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLaporan.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLaporan.Legends.Add(legend1);
            this.chartLaporan.Location = new System.Drawing.Point(135, 105);
            this.chartLaporan.Name = "chartLaporan";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLaporan.Series.Add(series1);
            this.chartLaporan.Size = new System.Drawing.Size(542, 300);
            this.chartLaporan.TabIndex = 0;
            this.chartLaporan.Text = "chart1";
            this.chartLaporan.Click += new System.EventHandler(this.chartLaporan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "LAPORAN HARIAN PENYEWAAN BAJU ADAT";
            // 
            // LaporanHarian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartLaporan);
            this.Name = "LaporanHarian";
            this.Text = "LaporanHarian";
            ((System.ComponentModel.ISupportInitialize)(this.chartLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLaporan;
        private System.Windows.Forms.Label label1;
    }
}