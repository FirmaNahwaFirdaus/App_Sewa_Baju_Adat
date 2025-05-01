using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Sewa_Baju_Adat
{

    public partial class Edit : Form
    {
        public event EventHandler DataEdited;

        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=sewa_baju_adat;");

        // Supaya ID tersimpan
        private int idEdit;

        public Edit()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.Edit_Load);

        }

        // Method LoadData untuk menerima data dari Riwayat
        public void LoadData(int id, string namaPenyewa, string bajuAdat, string Ukuran, DateTime tanggalSewa,
            int jumlahBarang, int jumlahHari, string pengiriman, decimal totalHarga, string metodeBayar)
        {
            idEdit = id; // <-- simpan ke variabel class, bukan ke parameter
            namapenyewa.Text = namaPenyewa;
            opsibajuadat.Text = bajuAdat;
            ukuran.Text = Ukuran;
            tanggal.Value = tanggalSewa;
            jumlahbarang.Text = jumlahBarang.ToString();
            jumlah.Text = jumlahHari.ToString();
            this.pengiriman.Text = pengiriman;
            totalharga.Text = totalHarga.ToString();
            metodepembayaran.Text = metodeBayar;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Main_Page_Load is called");
            opsibajuadat.Items.Add("Kebaya");
            opsibajuadat.Items.Add("Kebaya Sunda");
            opsibajuadat.Items.Add("Kebaya Bali");
            opsibajuadat.Items.Add("Baju Bodo");
            opsibajuadat.Items.Add("Baju Lurik");
            opsibajuadat.Items.Add("Jarik");
            opsibajuadat.Items.Add("Blangkon");
            opsibajuadat.Items.Add("Udeng");
            ukuran.Items.Add("S");
            ukuran.Items.Add("M");
            ukuran.Items.Add("L");
            ukuran.Items.Add("XL");
            ukuran.Items.Add("XXl");
            metodepembayaran.Items.Add("cash");
            metodepembayaran.Items.Add("transfer");
            pengiriman.Items.Add("Antar");
            pengiriman.Items.Add("Ambil");
            Console.WriteLine("Items added to ComboBox");

            jumlahbarang.TextChanged += new EventHandler(UpdateTotalHarga);
            jumlah.TextChanged += new EventHandler(UpdateTotalHarga);
            opsibajuadat.SelectedIndexChanged += new EventHandler(UpdateTotalHarga);
            pengiriman.SelectedIndexChanged += new EventHandler(UpdateTotalHarga);

            UpdateTotalHarga(sender, e);
        }

       
        private void btnsimpan_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = @"UPDATE sewa SET 
                                    nama_penyewa = @nama, 
                                    baju_adat = @baju_adat, 
                                    ukuran = @ukuran, 
                                    tanggal_sewa = @tanggal, 
                                    jumlah_barang = @jumlah_barang, 
                                    jumlah_hari = @jumlah_hari, 
                                    pengiriman = @pengiriman, 
                                    total_harga = @total_harga, 
                                    metode_bayar = @metode_bayar 
                                 WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", namapenyewa.Text.Trim());
                cmd.Parameters.AddWithValue("@baju_adat", opsibajuadat.Text.Trim());
                cmd.Parameters.AddWithValue("@ukuran", ukuran.Text.Trim());
                cmd.Parameters.AddWithValue("@tanggal", tanggal.Value);
                cmd.Parameters.AddWithValue("@jumlah_barang", int.Parse(jumlahbarang.Text.Trim()));
                cmd.Parameters.AddWithValue("@jumlah_hari", int.Parse(jumlah.Text.Trim()));
                cmd.Parameters.AddWithValue("@pengiriman", pengiriman.Text.Trim());
                cmd.Parameters.AddWithValue("@total_harga", decimal.Parse(totalharga.Text.Trim()));
                cmd.Parameters.AddWithValue("@metode_bayar", metodepembayaran.Text.Trim());
                cmd.Parameters.AddWithValue("@id", idEdit); // <-- pakai idEdit di sini

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diperbarui!");
                this.DialogResult = DialogResult.OK; // supaya Riwayat bisa refresh
                this.Close();

                if (this.DataEdited != null)
                    this.DataEdited(this, EventArgs.Empty);

                // Lalu close form edit
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan perubahan: " + ex.Message);
            }
        }

        private void UpdateTotalHarga(object sender, EventArgs e)
        {
            int jumlahBarang = 0;
            int jumlahHari = 0;

            // Cek jika nilai jumlah barang dan jumlah hari valid
            if (int.TryParse(jumlahbarang.Text.Trim(), out jumlahBarang) && int.TryParse(jumlah.Text.Trim(), out jumlahHari))
            {
                int hargaPerItem = 0;

                // Mengatur harga berdasarkan pilihan baju adat
                switch (opsibajuadat.Text)
                {
                    case "Kebaya":
                    case "Kebaya Sunda":
                        hargaPerItem = 50000;
                        break;
                    case "Kebaya Bali":
                        hargaPerItem = 55000;
                        break;
                    case "Baju Bodo":
                        hargaPerItem = 60000;
                        break;
                    case "Baju Lurik":
                        hargaPerItem = 35000;
                        break;
                    case "Jarik":
                        hargaPerItem = 30000;
                        break;
                    case "Blangkon":
                        hargaPerItem = 10000;
                        break;
                    case "Udeng":
                        hargaPerItem = 10000;
                        break;
                    default:
                        hargaPerItem = 0;
                        break;
                }

                // Menghitung total pembayaran
                int totalPembayaran = jumlahBarang * jumlahHari * hargaPerItem;

                // Menambahkan biaya pengiriman jika pengiriman "Antar"
                if (pengiriman.Text == "Antar")
                {
                    totalPembayaran += 2000;
                }

                // Menampilkan total pembayaran
                totalharga.Text = totalPembayaran.ToString("N0");
            }
            else
            {
                totalharga.Text = "0";
            }
        }
    }
}
