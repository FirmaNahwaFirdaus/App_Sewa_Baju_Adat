using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App_Sewa_Baju_Adat.Models
{
        public class Sewa
        {
            public int Id { get; set; }
            public string NamaPenyewa { get; set; }
            public string BajuAdat { get; set; }
            public string Ukuran { get; set; }
            public DateTime TanggalSewa { get; set; }
            public int JumlahBarang { get; set; }
            public int JumlahHari { get; set; }
            public string Pengiriman { get; set; }
            public string Alamat { get; set; }
            public decimal TotalHarga { get; set; }
            public string MetodeBayar { get; set; }
        }

}
