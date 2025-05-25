using MySql.Data.MySqlClient;
using System;
using System.Data;
using App_Sewa_Baju_Adat.Models;

namespace App_Sewa_Baju_Adat.Models
{
    public static class CRUD
    {
        // CREATE - Menambah data baru ke database
        public static void Create(Sewa sewa)
        {
            string query = @"INSERT INTO sewa 
                (nama_penyewa, baju_adat, ukuran, tanggal_sewa, jumlah_barang, jumlah_hari, pengiriman, alamat, total_harga, metode_bayar)
                VALUES (@nama, @baju, @ukuran, @tanggal, @barang, @hari, @pengiriman, @alamat, @total, @metodebayar)";

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", sewa.NamaPenyewa);
                    cmd.Parameters.AddWithValue("@baju", sewa.BajuAdat);
                    cmd.Parameters.AddWithValue("@ukuran", sewa.Ukuran);
                    cmd.Parameters.AddWithValue("@tanggal", sewa.TanggalSewa);
                    cmd.Parameters.AddWithValue("@barang", sewa.JumlahBarang);
                    cmd.Parameters.AddWithValue("@hari", sewa.JumlahHari);
                    cmd.Parameters.AddWithValue("@pengiriman", sewa.Pengiriman);
                    cmd.Parameters.AddWithValue("@alamat", sewa.Alamat);
                    cmd.Parameters.AddWithValue("@total", sewa.TotalHarga);
                    cmd.Parameters.AddWithValue("@metodebayar", sewa.MetodeBayar);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // READ - Mengambil semua data transaksi
        public static DataTable ReadAll()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sewa";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // SEARCH - Mencari data berdasarkan nama penyewa
        public static DataTable Search(string keyword)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sewa WHERE nama_penyewa LIKE @keyword";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // UPDATE - Mengupdate data transaksi
        public static void Update(Sewa sewa)
        {
            string query = @"UPDATE sewa SET 
                nama_penyewa = @nama, baju_adat = @baju, ukuran = @ukuran, tanggal_sewa = @tanggal,
                jumlah_barang = @barang, jumlah_hari = @hari, pengiriman = @pengiriman,
                alamat = @alamat, total_harga = @total, metode_bayar = @metodebayar
                WHERE id = @id";

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", sewa.Id);
                    cmd.Parameters.AddWithValue("@nama", sewa.NamaPenyewa);
                    cmd.Parameters.AddWithValue("@baju", sewa.BajuAdat);
                    cmd.Parameters.AddWithValue("@ukuran", sewa.Ukuran);
                    cmd.Parameters.AddWithValue("@tanggal", sewa.TanggalSewa);
                    cmd.Parameters.AddWithValue("@barang", sewa.JumlahBarang);
                    cmd.Parameters.AddWithValue("@hari", sewa.JumlahHari);
                    cmd.Parameters.AddWithValue("@pengiriman", sewa.Pengiriman);
                    cmd.Parameters.AddWithValue("@alamat", sewa.Alamat);
                    cmd.Parameters.AddWithValue("@total", sewa.TotalHarga);
                    cmd.Parameters.AddWithValue("@metodebayar", sewa.MetodeBayar);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE - Menghapus data transaksi
        public static void Delete(int id)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM sewa WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
