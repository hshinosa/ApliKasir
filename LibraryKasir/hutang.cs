using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryKasir.barang;

namespace LibraryKasir
{
    public static class hutang
    {
        public struct htg
        {
            public string nama;
            public int total;
        }

        //menambahkan data hutang, jika ada pelanggan yang berhutang
        public static void addhutang(htg[] htg, int n, string nama, int total)
        {
            htg[n].nama = nama;
            htg[n].total = total;
            n++;
        }

        //menghitung semua total hutang pelanggan yang ada di toko 
        public static int totalsemuahutang(htg[] htg)
        {
            int total = 0;
            for (int i = 0; i < htg.Length; i++) { 
                total = total + htg[i].total;
            }
            return total;
        }

        public static int cariidxhutang(htg[] htg, string nama)
        {
            int i = 0;
            bool ketemu = false;
            while (i <= htg.Length && ketemu == false)
            {
                if (htg[i].nama == nama)
                {
                    ketemu = true;
                }
                else
                {
                    i++;
                }
            }
            if (ketemu = false)
            {
                return -1;
            }
            else
            {
                return i;
            }
        }
        public static void deletehutang(htg[] htg, string nama)
        {
            int idx = cariidxhutang(htg, nama);

            if (idx != -1)
            {
                // Buat array baru dengan satu elemen kurang dari array asli
                htg[] newArray = new htg[htg.Length - 1];

                // Salin elemen-elemen sebelum item yang ingin dihapus
                Array.Copy(htg, 0, newArray, 0, idx);

                // Salin elemen-elemen setelah item yang ingin dihapus
                Array.Copy(htg, idx + 1, newArray, idx, htg.Length - idx - 1);

                // Perbarui array asli dengan array baru
                htg = newArray;

                Console.WriteLine("Data hutang dengan nama " + nama + " berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Maaf nama yang anda masukan tidak tersedia");
            }
        }
    }
}
