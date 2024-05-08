using System.Net.Http.Json;
using System.Text.Json;
using LibraryKasir;
using static LibraryKasir.Menu;

internal class Program
{
    static async Task Main(string[] args)
    {
        string baseUrl = "https://localhost:7222";

        static NamaMenu GetMenuChoice()
        {
            Console.Write("Masukkan pilihan: ");
            string choice = Console.ReadLine();
            return LibraryKasir.Menu.getNamaMenu(choice).Value;
        }

        while (true)
        {
            LibraryKasir.Menu.DisplayMenu();
            LibraryKasir.Menu.NamaMenu choice = GetMenuChoice();

            switch (choice)
            {
                case Menu.NamaMenu.InputDataBarang:
                    // Data Barang
                    Console.WriteLine("Data Barang");
                    Console.Write("Masukkan ID Barang : ");
                    int idBarang = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Masukkan Nama Barang : ");
                    string namaBarang = Console.ReadLine();
                    Console.Write("Masukkan Harga Barang : ");
                    double hargaBarang = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Masukkan Jumlah Barang : ");
                    int jumlahBarang = Convert.ToInt32(Console.ReadLine());

                    LibraryKasir.DataBarang barang = new LibraryKasir.DataBarang
                    {
                        idBarang = idBarang,
                        namaBarang = namaBarang,
                        hargaBarang = hargaBarang,
                        jumlahBarang = jumlahBarang
                    };

                    await LibraryKasir.Barang.CreateBarang(baseUrl, barang);
                    break;
                case Menu.NamaMenu.InputDataTransaksi:
                    // Data Transaksi
                    Console.WriteLine("Data Transaksi");
                    Console.Write("Masukkan ID Transaksi : ");
                    int idTransaksi = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Masukkan Nama Barang : ");
                    namaBarang = Console.ReadLine();
                    Console.Write("Masukkan Jumlah Barang : ");
                    jumlahBarang = Convert.ToInt32(Console.ReadLine());

                    // Retrieve the hargaBarang from the DataBarang data
                    hargaBarang = await Hitung.GetHargaBarang(baseUrl, namaBarang);

                    // Calculate the totalHarga
                    double totalHarga = hargaBarang * jumlahBarang;

                    LibraryKasir.DataTransaksi transaksi = new LibraryKasir.DataTransaksi
                    {
                        idTransaksi = idTransaksi,
                        namaBarang = namaBarang,
                        jumlahBarang = jumlahBarang,
                        totalHarga = totalHarga
                    };

                    await LibraryKasir.Hitung.CreateTransaksi(baseUrl, transaksi);
                    break;
                case Menu.NamaMenu.InputDataHutang:
                    // Data Hutang
                    Console.WriteLine("Data Hutang");
                    Console.Write("Masukkan ID Hutang : ");
                    int idHutang = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Masukkan Nama Pelanggan : ");
                    string namaPelanggan = Console.ReadLine();
                    Console.Write("Masukkan Nama Barang : ");
                    namaBarang = Console.ReadLine();
                    Console.Write("Masukkan Jumlah Barang : ");
                    jumlahBarang = Convert.ToInt32(Console.ReadLine());

                    // Retrieve the hargaBarang from the DataBarang data
                    hargaBarang = await LibraryKasir.Hitung.GetHargaBarang(baseUrl, namaBarang);

                    // Calculate the totalHarga
                    totalHarga = hargaBarang * jumlahBarang;

                    LibraryKasir.DataHutang hutang = new LibraryKasir.DataHutang
                    {
                        idHutang = idHutang,
                        namaPelanggan = namaPelanggan,
                        namaBarang = namaBarang,
                        jumlahBarang = jumlahBarang,
                        totalHarga = totalHarga
                    };

                    await LibraryKasir.Hutang.CreateHutang(baseUrl, hutang);
                    break;
                case Menu.NamaMenu.TampilkanDataBarang:
                    await LibraryKasir.Display.DisplayData(baseUrl, "/DataBarang");
                    break;
                case Menu.NamaMenu.TampilkanDataTransaksi:
                    await LibraryKasir.Display.DisplayData(baseUrl, "/DataTransaksi");
                    break;
                case Menu.NamaMenu.TampilkanDataHutang:
                    await LibraryKasir.Display.DisplayData(baseUrl, "/DataHutang");
                    break;
                case Menu.NamaMenu.HapusDataBarang:
                    await LibraryKasir.Display.DisplayData(baseUrl, "/DataBarang");
                    Console.WriteLine("Masukkan ID Barang : ");
                    idBarang = Convert.ToInt32(Console.ReadLine());
                    await LibraryKasir.Barang.DeleteBarang(baseUrl, idBarang);
                    break;
                case Menu.NamaMenu.HapusDataTransaksi:
                    await LibraryKasir.Display.DisplayData(baseUrl, "/DataTransaksi");
                    Console.WriteLine("Masukkan ID Transaksi : ");
                    idTransaksi = Convert.ToInt32(Console.ReadLine());
                    await LibraryKasir.Barang.DeleteBarang(baseUrl, idTransaksi);
                    break;
                case Menu.NamaMenu.HapusDataHutang:
                    await LibraryKasir.Display.DisplayData(baseUrl, "/DataHutang");
                    Console.WriteLine("Masukkan ID Hutang : ");
                    idHutang = Convert.ToInt32(Console.ReadLine());
                    await LibraryKasir.Barang.DeleteBarang(baseUrl, idHutang);
                    break;
                case Menu.NamaMenu.Keluar:
                    Console.WriteLine("Terima kasih telah menggunakan!");
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }
}