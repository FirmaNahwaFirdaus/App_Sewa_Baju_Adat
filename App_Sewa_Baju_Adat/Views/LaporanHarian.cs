using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace App_Sewa_Baju_Adat.Views
{
    public partial class LaporanHarian : Form
    {
        public LaporanHarian()
        {
            InitializeComponent();
            this.Load += LaporanHarian_Load; // Gunakan nama method yang konsisten
        }

        private void LaporanHarian_Load(object sender, EventArgs e)
        {
            // Inisialisasi Chart
            chartLaporan.Series.Clear();
            chartLaporan.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea("ChartAreaUtama");
            chartLaporan.ChartAreas.Add(chartArea);

            Series series = new Series("Total Transaksi")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String
            };

            try
            {
                // Ambil data dari database
                Dictionary<DateTime, int> dataHarian = AmbilDataTransaksiHarian();

                foreach (var item in dataHarian)
                {
                    series.Points.AddXY(item.Key.ToString("dd/MM"), item.Value);
                }

                chartLaporan.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data grafik: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<DateTime, int> AmbilDataTransaksiHarian()
        {
            var data = new Dictionary<DateTime, int>();

            string query = @"
                SELECT DATE(tanggal_sewa) AS Tanggal, COUNT(*) AS Jumlah 
                FROM sewa 
                GROUP BY DATE(tanggal_sewa) 
                ORDER BY Tanggal DESC 
                LIMIT 7";

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                        {
                            DateTime tanggal = reader.GetDateTime("Tanggal");
                            int jumlah = reader.GetInt32("Jumlah");
                            data[tanggal] = jumlah;
                        }
                    }
                }
            }

            // Urutkan data dari tanggal terlama ke terbaru (karena query pakai DESC)
            var sortedData = new SortedDictionary<DateTime, int>(data);
            return new Dictionary<DateTime, int>(sortedData);
        }

        private void chartLaporan_Click(object sender, EventArgs e)
        {

        }
    }
}
