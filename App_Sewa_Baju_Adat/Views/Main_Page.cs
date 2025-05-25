using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using App_Sewa_Baju_Adat.Models;

namespace App_Sewa_Baju_Adat.Views
{
    public partial class Main_Page : Form
    {
        private MySqlConnection conn;

        public Main_Page()
        {
            InitializeComponent();
            TransaksiBerhasil += Main_Page_TransaksiBerhasil;
        }

        public event EventHandler TransaksiBerhasil;

        private void Main_Page_Load(object sender, EventArgs e)
        {
            pilihbajuadat.Items.AddRange(new string[] {
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

        private void pilihbajuadat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (pilihbajuadat.Text)
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
                // Membuat objek Sewa
                Sewa sewa = new Sewa
                {
                    NamaPenyewa = namapenyewa.Text,
                    BajuAdat = pilihbajuadat.Text,
                    Ukuran = ukuran.Text,
                    TanggalSewa = DateTime.Now,
                    JumlahBarang = Convert.ToInt32(jumlahbarang.Text),
                    JumlahHari = Convert.ToInt32(Jumlah.Text),
                    Pengiriman = pengiriman.Text,
                    Alamat = alamat.Text,
                    MetodeBayar = metodepembayaran.Text,
                };

                // Menghitung total harga
                if (!int.TryParse(Harga.Text, out int harga) || !int.TryParse(jumlahbarang.Text, out int jumlahBarang))
                {
                    MessageBox.Show("Masukkan angka valid untuk harga dan jumlah barang", "Peringatan");
                    return;
                }

                int total = jumlahBarang * sewa.JumlahHari * harga;
                if (pengiriman.Text == "Antar") total += 2000;

                sewa.TotalHarga = total;

                // Menyimpan data menggunakan CRUD
                CRUD.Create(sewa);

                TransaksiBerhasil?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error");
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
            var riwayatForm = new Riwayat();

            riwayatForm.Show();
        }


        private void keluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlaporan_Click(object sender, EventArgs e)
        {
            LaporanHarian formLaporan = new LaporanHarian();
            formLaporan.ShowDialog(); // gunakan ShowDialog jika ingin modal, atau Show jika tidak
        }

    }
}
