using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryKasir
{
    public class DataTransaksi
    {
        public int idTransaksi { get; set; }
        public string namaBarang { get; set; }
        public int jumlahBarang { get; set; }
        public double totalHarga { get; set; }
    }
}
