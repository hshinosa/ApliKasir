using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryKasir
{
    public static class barang
    {
        public struct brg
        {
            public string nama;
            public int harga;
            public int stok;
            public int id;
        }
        public static void InsertBarang(int id, string nama, int harga, int stok, brg[] brg, int idx)
        {
            brg[idx].id = idx;
            brg[idx].nama = nama;
            brg[idx].harga = harga;
            brg[idx].stok = stok;
            idx++;
        }

        public static int cariidxbarang(brg[] brg, string nama)
        {
            int i = 0;
            bool ketemu = false;
            while (i <= brg.Length && ketemu == false)
            {
                if (brg[i].nama == nama)
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

        public static void editnamabarang(brg[] brg, string namalama, string namabaru)
        {
            int idx = cariidxbarang(brg,namalama);
            
            if (idx != -1)
            {
                brg[idx].nama = namabaru;
                Console.WriteLine("nama baru sudah dicatat");
            } else
            {
                Console.WriteLine("Maaf nama yang anda masukan tidak tersedia");
            }
        }

        public static void edithargabarang(brg[] brg, string nama, int hargabaru)
        {
            int idx = cariidxbarang(brg, nama);

            if (idx != -1)
            {
                brg[idx].harga = hargabaru;
                Console.WriteLine("harga baru sudah dicatat");
            }
            else
            {
                Console.WriteLine("Maaf nama yang anda masukan tidak tersedia");
            }
        }

        public static void deletedatabarang(brg[] brg, string nama)
        { 
            int idx = cariidxbarang(brg,nama);
            bool ketemu = false;

            if (idx != -1)
            {
                // Buat array baru dengan satu elemen kurang dari array asli
                brg[] newArray = new brg[brg.Length - 1];

                // Salin elemen-elemen sebelum item yang ingin dihapus
                Array.Copy(brg, 0, newArray, 0, idx);

                // Salin elemen-elemen setelah item yang ingin dihapus
                Array.Copy(brg, idx + 1, newArray, idx, brg.Length - idx - 1);

                // Perbarui array asli dengan array baru
                brg = newArray;

                Console.WriteLine("Data barang dengan nama " + nama + " berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Maaf nama yang anda masukan tidak tersedia");
            }
        }
    }
}
