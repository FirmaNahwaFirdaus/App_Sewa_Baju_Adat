using System.Data;
using App_Sewa_Baju_Adat.Models;

namespace App_Sewa_Baju_Adat.Controllers
{
    public class SewaController
    {
        // Ambil semua data sewa
        public DataTable GetAllSewa()
        {
            return CRUD.ReadAll();
        }

        // Tambah sewa baru
        public void TambahSewa(Sewa data)
        {
            CRUD.Create(data);
        }

        // Edit data sewa
        public void EditSewa(Sewa data)
        {
            CRUD.Update(data);
        }

        // Hapus data sewa
        public void HapusSewa(int id)
        {
            CRUD.Delete(id);
        }

        // Cari data sewa berdasarkan nama penyewa
        public DataTable CariSewa(string keyword)
        {
            return CRUD.Search(keyword);
        }
    }
}
