using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace App_Sewa_Baju_Adat
{
    public partial class Main_Page : Form
    {
        private MySqlConnection conn = new MySqlConnection("server=localhost; database=sewa_baju_adat; uid=root; pwd=;");

        public Main_Page()
        {
            InitializeComponent();
            TransaksiBerhasil += Main_Page_TransaksiBerhasil;
        }

        public event EventHandler TransaksiBerhasil;

        private void Main_Page_Load(object sender, EventArgs e)
        {
            opsibajuadat.Items.AddRange(new string[] {
                "Kebaya", "Kebaya Sunda", "Kebaya Bali",
                "Baju Bodo", "Baju Lurik", "Jarik",
                "Blangkon", "Udeng"
            });

            ukuran.Items.AddRange(new string[] { "S", "M", "L", "XL", "XXL" });
            metodepembayaran.Items.AddRange(new string[] { "cash", "transfer" });
            konfirmasibayar.Items.AddRange(new string[] { "Belum Bayar", "Sudah Bayar" });
            pengiriman.Items.AddRange(new string[] { "Antar", "Ambil" });
        }

        private void Main_Page_TransaksiBerhasil(object sender, EventArgs e)
        {
            MessageBox.Show("Transaksi Berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void opsibajuadat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (opsibajuadat.Text)
            {
                case "Kebaya":
                case "Kebaya Sunda":
                    Harga.Text = "50000"; break;
                case "Kebaya Bali":
                    Harga.Text = "55000"; break;
                case "Baju Bodo":
                    Harga.Text = "65000"; break;
                case "Baju Lurik":
                    Harga.Text = "35000"; break;
                case "Jarik":
                    Harga.Text = "30000"; break;
                case "Blangkon":
                case "Udeng":
                    Harga.Text = "10000"; break;
                default:
                    Harga.Clear(); break;
            }
        }

        private void Total_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Jumlah.Text, out int jumlahHari) ||
                !int.TryParse(Harga.Text, out int harga) ||
                !int.TryParse(jumlahbarang.Text, out int jumlahBarang))
            {
                MessageBox.Show("Masukkan angka valid untuk hari, harga, dan jumlah barang", "Peringatan");
                return;
            }

            if (string.IsNullOrWhiteSpace(pengiriman.Text))
            {
                MessageBox.Show("Pilih pengiriman", "Peringatan");
                return;
            }

            int total = jumlahBarang * jumlahHari * harga;
            if (pengiriman.Text == "Antar") total += 2000;

            totalharga.Text = total.ToString("N0");
        }

        private void simpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(namapenyewa.Text))
            {
                MessageBox.Show("Masukkan nama penyewa", "Peringatan");
                return;
            }

            if (konfirmasibayar.Text != "Sudah Bayar")
            {
                MessageBox.Show("Lakukan Pembayaran Terlebih Dahulu");
                return;
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string query = @"INSERT INTO sewa (nama_penyewa, baju_adat, ukuran, tanggal_sewa, 
                                jumlah_barang, jumlah_hari, pengiriman, alamat, total_harga, metode_bayar) 
                                VALUES (@nama, @baju, @ukuran, @tanggal, @barang, @hari, @pengiriman, @alamat, @total, @metodebayar)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", namapenyewa.Text);
                    cmd.Parameters.AddWithValue("@baju", opsibajuadat.Text);
                    cmd.Parameters.AddWithValue("@ukuran", ukuran.Text);
                    cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@barang", Convert.ToInt32(jumlahbarang.Text));
                    cmd.Parameters.AddWithValue("@hari", Convert.ToInt32(Jumlah.Text));
                    cmd.Parameters.AddWithValue("@pengiriman", pengiriman.Text);
                    cmd.Parameters.AddWithValue("@alamat", alamat.Text);
                    cmd.Parameters.AddWithValue("@metodebayar", metodepembayaran.Text);

                    if (!int.TryParse(totalharga.Text.Replace(".", "").Replace(",", ""), out int totalHarga))
                    {
                        MessageBox.Show("Total harga tidak valid!", "Error");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@total", totalHarga);

                    cmd.ExecuteNonQuery();
                }

                TransaksiBerhasil?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void Hapus_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox) ((TextBox)c).Clear();
                else if (c is ComboBox) ((ComboBox)c).SelectedIndex = -1;
            }

            tanggal.Text = "";  // Karena TextBox biasa
        }

        private void Riwayat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Riwayat().Show();
        }

        private void keluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
