namespace API
{
    public class DataBarang
    {
        public int idBarang { get; set; }
        public string namaBarang { get; set; }
        public double hargaBarang { get; set; }
        public int jumlahBarang { get; set; }
    
        public DataBarang(int idBarang, string namaBarang, double hargaBarang, int jumlahBarang)
        {
            this.idBarang = idBarang;
            this.namaBarang = namaBarang;
            this.hargaBarang = hargaBarang;
            this.jumlahBarang = jumlahBarang;
        }
    }

    
}
