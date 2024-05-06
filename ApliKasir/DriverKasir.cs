using ApliKasir;
using System.Net.Http.Json;
using System.Text.Json;

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
            Console.WriteLine("7. Keluar");
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

                    await DataAkses.CreateBarang(baseUrl, barang);
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
                    hargaBarang = await DataAkses.GetHargaBarang(baseUrl, namaBarang);

                    // Calculate the totalHarga
                    double totalHarga = hargaBarang * jumlahBarang;

                    DataTransaksi transaksi = new DataTransaksi
                    {
                        idTransaksi = idTransaksi,
                        namaBarang = namaBarang,
                        jumlahBarang = jumlahBarang,
                        totalHarga = totalHarga
                    };

                    await DataAkses.CreateTransaksi(baseUrl, transaksi);
                    break;

                case 3:
                    // Data Hutang
                    Console.WriteLine("Data Hutang");
                    Console.Write("Masukkan ID Hutang : ");
                    int idHutang = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Masukkan Nama Pelanggan");
                    string namaPelanggan = Console.ReadLine();
                    Console.Write("Masukkan Nama Barang : ");
                    namaBarang = Console.ReadLine();
                    Console.Write("Masukkan Jumlah Barang : ");
                    jumlahBarang = Convert.ToInt32(Console.ReadLine());

                    // Retrieve the hargaBarang from the DataBarang data
                    hargaBarang = await DataAkses.GetHargaBarang(baseUrl, namaBarang);

                    // Calculate the totalHarga
                    totalHarga = hargaBarang * jumlahBarang;

                    DataHutang hutang = new DataHutang
                    {
                        idHutang = idHutang,
                        namaPelanggan = namaPelanggan,
                        namaBarang = namaBarang,
                        jumlahBarang = jumlahBarang,
                        totalHarga = totalHarga
                    };

                    await DataAkses.CreateHutang(baseUrl, hutang);
                    break;

                case 4:
                    await DataAkses.DisplayData(baseUrl, "/DataBarang");
                    break;

                case 5:
                    await DataAkses.DisplayData(baseUrl, "/DataTransaksi");
                    break;

                case 6:
                    await DataAkses.DisplayData(baseUrl, "/DataHutang");
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static async Task GetData(string baseUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/DataBarang");
                response.EnsureSuccessStatusCode(); // Throw if not a success code

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static async Task AddData(string baseUrl,int IdBarang,string NamaBarang,double HargaBarang,int JumlahBarang)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                DataBarang newData = new DataBarang
                {
                    // Initialize with your desired values
                    idBarang = IdBarang,
                    namaBarang = NamaBarang,
                    hargaBarang = HargaBarang,
                    jumlahBarang= JumlahBarang
                };

                HttpResponseMessage response = await client.PostAsJsonAsync($"{baseUrl}/DataBarang", newData);
                response.EnsureSuccessStatusCode(); // Throw if not a success code

                Console.WriteLine("New data added successfully.");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static async Task DeleteData(string baseUrl, int id)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/DataBarang/{id}");
                response.EnsureSuccessStatusCode(); // Throw if not a success code

                Console.WriteLine($"Data with ID {id} deleted successfully.");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}