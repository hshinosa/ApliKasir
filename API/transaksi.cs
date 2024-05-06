namespace API
{
    public class transaksi
    {
        public int idTransaksi { get; set; }
        public string namaBarang { get; set; }
        public int jumlahBarang { get; set; }
        public double totalHarga { get; set; }


        public DataBarang(int id, string nama, int jumlah, double total)
        {
            this.idTransaksi = id;
            this.namaBarang = nama;
            this.jumlahBarang = jumlah;
            this.totalHarga = total;
        }
    }
}
