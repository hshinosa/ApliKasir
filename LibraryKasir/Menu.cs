using System;
using System.Collections.Generic;

namespace LibraryKasir
{
    public static class Menu
    {
        public enum NamaMenu
        {
            InputDataBarang,
            InputDataTransaksi,
            InputDataHutang,
            TampilkanDataBarang,
            TampilkanDataTransaksi,
            TampilkanDataHutang,
            HapusDataBarang,
            HapusDataTransaksi,
            HapusDataHutang,
            Keluar
        }

        private static readonly Dictionary<NamaMenu, string> _kodeMenuTabel;
        private static readonly Dictionary<string, NamaMenu> _menuKodeTabel;

        static Menu()
        {
            _kodeMenuTabel = new Dictionary<NamaMenu, string>
            {
                { NamaMenu.InputDataBarang, "1" },
                { NamaMenu.InputDataTransaksi, "2" },
                { NamaMenu.InputDataHutang, "3" },
                { NamaMenu.TampilkanDataBarang, "4" },
                { NamaMenu.TampilkanDataTransaksi, "5" },
                { NamaMenu.TampilkanDataHutang, "6" },
                { NamaMenu.HapusDataBarang, "7" },
                { NamaMenu.HapusDataTransaksi, "8" },
                { NamaMenu.HapusDataHutang, "9" },
                { NamaMenu.Keluar, "10" }
            };

            _menuKodeTabel = new Dictionary<string, NamaMenu>(_kodeMenuTabel.ToDictionary(x => x.Value, x => x.Key));
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("ApliKasir");
            foreach (var menu in _kodeMenuTabel)
            {
                Console.WriteLine($"{menu.Value}. {menu.Key}");
            }
        }

        public static string GetKodeMenu(NamaMenu menu)
        {
            if (!_kodeMenuTabel.TryGetValue(menu, out string kode))
            {
                throw new ArgumentException($"Invalid menu: {menu}", nameof(menu));
            }
            return kode;
        }

        public static NamaMenu? GetNamaMenu(string kode)
        {
            if (!_menuKodeTabel.TryGetValue(kode, out NamaMenu namaMenu))
            {
                return null;
            }
            return namaMenu;
        }
    }
}