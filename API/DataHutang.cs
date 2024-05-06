namespace API
{
    public class DataHutang
    {
        public int idHutang { get; set; }
        public string namaPelanggan { get; set; }
        public string namaBarang { get; set; }
        public int jumlahBarang { get; set; }
        public double totalHarga { get; set; }

        public DataHutang(int idHutang, string namaPelanggan, string namaBarang, int jumlahBarang, double totalHarga)
        {
            this.idHutang = idHutang;
            this.namaPelanggan = namaPelanggan;
            this.namaBarang = namaBarang;
            this.jumlahBarang = jumlahBarang;
            this.totalHarga = totalHarga;
        }
    }
}
