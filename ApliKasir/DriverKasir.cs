using static Menu;

public class Menu
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

    private static Dictionary<NamaMenu, string> kodeMenuTabel = new Dictionary<NamaMenu, string>
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

    private static Dictionary<string, NamaMenu> menuKodeTabel = new Dictionary<string, NamaMenu>
    {
        { "1", NamaMenu.InputDataBarang},
        { "2", NamaMenu.InputDataTransaksi},
        { "3", NamaMenu.InputDataHutang},
        { "4", NamaMenu.TampilkanDataBarang},
        { "5", NamaMenu.TampilkanDataTransaksi},
        { "6", NamaMenu.TampilkanDataHutang},
        { "7", NamaMenu.HapusDataBarang},
        { "8", NamaMenu.HapusDataTransaksi},
        { "9", NamaMenu.HapusDataHutang},
        { "10", NamaMenu.Keluar}
    };

    public static string getKodemenu(NamaMenu menu)
    {
        return kodeMenuTabel.GetValueOrDefault(menu, "Kode menu tidak ditemukan");
    }

    public static NamaMenu? getNamaMenu(string kode)
    {
        if (menuKodeTabel.TryGetValue(kode, out NamaMenu namaMenu))
        {
            return namaMenu;
        }
        else
        {
            return null;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Masukkan kode menu: ");
            string kodeMenu = Console.ReadLine();

            NamaMenu? NamaMenu = Menu.getNamaMenu(kodeMenu);

            if (NamaMenu == null)
            {
                Console.WriteLine("Input salah, input ulang.");
            }
            else
            {
                Console.WriteLine($"Nama menu: {NamaMenu}");
            }
        }
    }
}