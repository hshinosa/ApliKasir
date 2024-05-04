namespace LibraryKasir
{
        public static class hitung
        {
            public static int transaksi(int jumlah, int harga)
            {
                return jumlah * harga;
            }

            public static void pemasukan(int jumlah, int harga, int i, int[] masuk)
            {
                int transaksi = hitung.transaksi(jumlah, harga);
                masuk[i] = transaksi;
                i = i + 1;
            }

            public static int keuntungan(int[] masuk, int n, int modal)
            {
                int total = 0;
                for (int i = 0; i < n; i++)
                {
                    total = total + masuk[i];
                }

                return total - modal;
            }
        }
}
