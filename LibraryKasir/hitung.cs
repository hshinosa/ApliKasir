using static LibraryKasir.barang;
namespace LibraryKasir
{
        public static class hitung
        {
            public static int transaksi(int jumlah, int harga)
            {
                return jumlah * harga;
            }

            public static void pemasukan(string nama, brg[] brg, int jumlah, int harga, int[] masuk, int i)
            {
                if (cariidxbarang(brg, nama) == -1)
                {
                    Console.WriteLine("Mohon Maaf, Barang tidak tersedia :(");
                }
                else
                {
                    brg[cariidxbarang(brg, nama)].stok = brg[cariidxbarang(brg, nama)].stok - jumlah;
                }
                
                int transaksi = hitung.transaksi(jumlah, harga);
                masuk[i] = transaksi;
                i = i + 1;
                Console.WriteLine("Transaksi Pemasukan Sudah Dicatat");
            }

            public static int keuntungan(int[] masuk, int modal)
            {
                int total = 0;
                for (int i = 0; i < masuk.Length; i++)
                {
                    total = total + masuk[i];
                }

                return total - modal;
            }

            public static void pengeluaran(int id, string nama, brg[] brg,  int n, int jumlah, int harga, int[] keluar, int i)
            {
                int transaksi = hitung.transaksi(jumlah, harga);
                keluar[i] = transaksi;
                i = i + 1;

                if (cariidxbarang(brg,nama) == -1)
                {
                    InsertBarang(id, nama, harga, jumlah, brg, n);
                } else
                {
                    brg[cariidxbarang(brg, nama)].stok = brg[cariidxbarang(brg, nama)].stok + jumlah;
                }

                Console.WriteLine("Pengeluaran Anda Sudah Dicatat");
            }

            
        }
}
