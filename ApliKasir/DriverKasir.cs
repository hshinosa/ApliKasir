using System.Net.Http.Json;
using System.Text.Json;
using LibraryKasir;

internal class Program
{
    static async Task Main(string[] args)
    {
        // Base URL of your API
        string baseUrl = "https://localhost:7058";

        while (true)
        {
            Console.WriteLine("ApliKasir");
            Console.WriteLine("1. Input Data Barang");
            Console.WriteLine("2. Input Data Transaksi");
            Console.WriteLine("3. Input Data Hutang");
            Console.WriteLine("4. Tampilkan Data Barang");
            Console.WriteLine("5. Tampilkan Data Transaksi");
            Console.WriteLine("6. Tampilkan Data Hutang");
            Console.WriteLine("7. Hapus Data Barang");
            Console.WriteLine("8. Hapus Data Transaksi");
            Console.WriteLine("9. Hapus Data Hutang");
            Console.WriteLine("10. Keluar");
            Console.Write("Pilih menu: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
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

                    DataBarang barang = new DataBarang
                    {
                        idBarang = idBarang,
                        namaBarang = namaBarang,
                        hargaBarang = hargaBarang,
                        jumlahBarang = jumlahBarang
                    };

                    await LibraryKasir.barang.CreateBarang(baseUrl, barang);
                    break;

                case 2:
                    // Data Transaksi
                    Console.WriteLine("Data Transaksi");
                    Console.Write("Masukkan ID Transaksi : ");
                    int idTransaksi = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Masukkan Nama Barang : ");
                    namaBarang = Console.ReadLine();
                    Console.Write("Masukkan Jumlah Barang : ");
                    jumlahBarang = Convert.ToInt32(Console.ReadLine());

                    // Retrieve the hargaBarang from the DataBarang data
                    hargaBarang = await hitung.GetHargaBarang(baseUrl, namaBarang);

                    // Calculate the totalHarga
                    double totalHarga = hargaBarang * jumlahBarang;

                    LibraryKasir.DataTransaksi transaksi = new LibraryKasir.DataTransaksi
                    {
                        idTransaksi = idTransaksi,
                        namaBarang = namaBarang,
                        jumlahBarang = jumlahBarang,
                        totalHarga = totalHarga
                    };

                    await LibraryKasir.hitung.CreateTransaksi(baseUrl, transaksi);
                    break;

                case 3:
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
                    hargaBarang = await LibraryKasir.hitung.GetHargaBarang(baseUrl, namaBarang);

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

                    await LibraryKasir.hutang.CreateHutang(baseUrl, hutang);
                    break;

                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }

            Console.WriteLine();
        }
    }
}