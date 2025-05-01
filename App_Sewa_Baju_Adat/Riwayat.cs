using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace App_Sewa_Baju_Adat
{
    public partial class Riwayat : Form
    {

        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=sewa_baju_adat;");

        public Riwayat()
        {
            InitializeComponent();
            LoadAllTransactions();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=sewa_baju_adat;"))
                {
                    conn.Open();
                    string keyword = txtCari.Text.Trim();
                    string query = "SELECT * FROM sewa WHERE nama_penyewa LIKE @keyword";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRiwayat.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data tidak ditemukan: " + ex.Message);
            }
        }

        private void LoadAllTransactions()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=sewa_baju_adat;"))
                {
                    conn.Open();
                    string query = "SELECT * FROM sewa";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRiwayat.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRiwayat.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvRiwayat.SelectedRows[0].Cells["id"].Value);
                string namaPenyewa = dgvRiwayat.SelectedRows[0].Cells["nama_penyewa"].Value.ToString();
                string bajuAdat = dgvRiwayat.SelectedRows[0].Cells["baju_adat"].Value.ToString();
                string ukuran = dgvRiwayat.SelectedRows[0].Cells["ukuran"].Value.ToString();
                DateTime tanggalSewa = Convert.ToDateTime(dgvRiwayat.SelectedRows[0].Cells["tanggal_sewa"].Value);
                int jumlahBarang = Convert.ToInt32(dgvRiwayat.SelectedRows[0].Cells["jumlah_barang"].Value);
                int jumlahHari = Convert.ToInt32(dgvRiwayat.SelectedRows[0].Cells["jumlah_hari"].Value);
                string pengiriman = dgvRiwayat.SelectedRows[0].Cells["pengiriman"].Value.ToString();
                decimal totalHarga = Convert.ToDecimal(dgvRiwayat.SelectedRows[0].Cells["total_harga"].Value);
                string metodeBayar = dgvRiwayat.SelectedRows[0].Cells["metode_bayar"].Value.ToString();

                // Buka form edit
                Edit formEdit = new Edit();
                formEdit.LoadData(id, namaPenyewa, bajuAdat, ukuran, tanggalSewa,
                                  jumlahBarang, jumlahHari, pengiriman, totalHarga, metodeBayar);

                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    formEdit.DataEdited += (s, args) =>
                    {
                        LoadAllTransactions();
                    };
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
                        using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=sewa_baju_adat;"))
                        {
                            conn.Open();
                            string query = "DELETE FROM sewa WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", idToDelete);

                            cmd.ExecuteNonQuery();
                        }

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
            this.Close();

            Main_Page mainForm = new Main_Page();
            mainForm.Show();
        }


        private void keluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
