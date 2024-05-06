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
                } else
                {
                    i++;
                }
            }
            if (ketemu = false)
            {
                return -1;
            } else
            {
                return i;
            }
        }
    }
}
