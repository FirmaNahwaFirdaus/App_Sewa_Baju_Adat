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
using App_Sewa_Baju_Adat.Models;

namespace App_Sewa_Baju_Adat.Views
{

    public partial class Edit : Form
    {
        public event EventHandler DataEdited;

        private int idEdit;

        public Edit()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.Edit_Load);

        }

        // Method LoadData untuk menerima data dari Riwayat
        public void LoadData(Sewa data)
        {
            idEdit = data.Id;
            namapenyewa.Text = data.NamaPenyewa;
            opsibajuadat.Text = data.BajuAdat;
            ukuran.Text = data.Ukuran;
            tanggal.Value = data.TanggalSewa;
            jumlahbarang.Text = data.JumlahBarang.ToString();
            jumlah.Text = data.JumlahHari.ToString();
            pengiriman.Text = data.Pengiriman;
            totalharga.Text = data.TotalHarga.ToString("N0");
            metodepembayaran.Text = data.MetodeBayar;
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
                Sewa data = new Sewa
                {
                    Id = idEdit,
                    NamaPenyewa = namapenyewa.Text.Trim(),
                    BajuAdat = opsibajuadat.Text.Trim(),
                    Ukuran = ukuran.Text.Trim(),
                    TanggalSewa = tanggal.Value,
                    JumlahBarang = int.Parse(jumlahbarang.Text.Trim()),
                    JumlahHari = int.Parse(jumlah.Text.Trim()),
                    Alamat = alamat.Text.Trim(),
                    Pengiriman = pengiriman.Text.Trim(),
                    TotalHarga = decimal.Parse(totalharga.Text.Trim()),
                    MetodeBayar = metodepembayaran.Text.Trim()
                };

                CRUD.Update(data); 

                MessageBox.Show("Data berhasil diperbarui!");

                DataEdited?.Invoke(this, EventArgs.Empty);
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
