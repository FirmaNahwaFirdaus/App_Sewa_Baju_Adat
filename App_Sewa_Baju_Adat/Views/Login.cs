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


namespace App_Sewa_Baju_Adat.Views
{ 
    public partial class Login : Form
    {
        public event EventHandler LoginBerhasil;

        MySqlConnection conn;

        public Login()
        {
            InitializeComponent();

            this.LoginBerhasil += Login_LoginBerhasil;
        }

        private void Login_LoginBerhasil(object sender, EventArgs e)
        {
            MessageBox.Show("Login berhasil! Selamat datang.");
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn = Database.GetConnection();
                conn.Open();

                string query = "SELECT * FROM login WHERE username=@username AND password=@password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    LoginBerhasil?.Invoke(this, EventArgs.Empty);

                    this.Hide();
                    Main_Page halamanUtama = new Main_Page();
                    halamanUtama.FormClosed += (s, args) => this.Close();
                    halamanUtama.Show();

                    Database.CloseConnection();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cekpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cekpass.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }
    }
}
