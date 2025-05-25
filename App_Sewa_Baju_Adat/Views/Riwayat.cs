using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using App_Sewa_Baju_Adat.Models;

namespace App_Sewa_Baju_Adat.Views
{
    public partial class Riwayat : Form
    {
        public event EventHandler DataEdited;

        public Riwayat()
        {
            InitializeComponent();
            LoadAllTransactions();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            dgvRiwayat.DataSource = CRUD.Search(txtCari.Text.Trim());
        }

        private void LoadAllTransactions()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM sewa";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    dgvRiwayat.AutoGenerateColumns = true;
                    dgvRiwayat.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message + "\n\nStackTrace:\n" + ex.StackTrace);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRiwayat.SelectedRows.Count > 0)
            {
                var row = dgvRiwayat.SelectedRows[0];

                Sewa data = new Sewa
                {
                    Id = Convert.ToInt32(row.Cells["id"].Value),
                    NamaPenyewa = row.Cells["nama_penyewa"].Value.ToString(),
                    BajuAdat = row.Cells["baju_adat"].Value.ToString(),
                    Ukuran = row.Cells["ukuran"].Value.ToString(),
                    TanggalSewa = Convert.ToDateTime(row.Cells["tanggal_sewa"].Value),
                    JumlahBarang = Convert.ToInt32(row.Cells["jumlah_barang"].Value),
                    JumlahHari = Convert.ToInt32(row.Cells["jumlah_hari"].Value),
                    Pengiriman = row.Cells["pengiriman"].Value.ToString(),
                    TotalHarga = Convert.ToDecimal(row.Cells["total_harga"].Value),
                    MetodeBayar = row.Cells["metode_bayar"].Value.ToString(),
                    Alamat = ""
                };

                Edit formEdit = new Edit();
                formEdit.LoadData(data); // Pastikan LoadData menerima parameter Sewa

                formEdit.DataEdited += (s, args) =>
                {
                    LoadAllTransactions();
                };

                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    LoadAllTransactions();
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin diedit.");
            }
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvRiwayat.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int idToDelete = Convert.ToInt32(dgvRiwayat.SelectedRows[0].Cells["id"].Value);

                    try
                    {
                        CRUD.Delete(idToDelete);
                        MessageBox.Show("Data berhasil dihapus!");
                        LoadAllTransactions();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus.");
            }
        }


        private void kembali_Click(object sender, EventArgs e)
        {
            Main_Page mainForm = new Main_Page();
            mainForm.Show();
            this.Close();
        }


        private void keluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
