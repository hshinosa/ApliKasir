namespace API
{
    public class DataTransaksi
    {
        public int idTransaksi { get; set; }
        public string namaBarang { get; set; }
        public int jumlahBarang { get; set; }
        public double totalHarga { get; set; }


        public DataTransaksi(int id, string nama, int jumlah, double total)
        {
            this.idTransaksi = id;
            this.namaBarang = nama;
            this.jumlahBarang = jumlah;
            this.totalHarga = total;
        }
    }
}
