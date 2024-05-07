
using System.Text;
using System.Text.Json;
using static LibraryKasir.barang;
namespace LibraryKasir
{
    public static class hitung
    {
        public static async Task<double> GetHargaBarang(string baseUrl, string namaBarang)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{baseUrl}/DataBarang");
                    response.EnsureSuccessStatusCode(); // Throw if not a success code
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var dataBarang = JsonSerializer.Deserialize<List<DataBarang>>(responseBody);

                    // Find the DataBarang with the matching namaBarang
                    var barang = dataBarang.FirstOrDefault(b => b.namaBarang == namaBarang);

                    if (barang != null)
                    {
                        return barang.hargaBarang;
                    }
                    else
                    {
                        Console.WriteLine($"Barang dengan nama '{namaBarang}' tidak ditemukan.");
                        return 0;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return 0;
                }
            }
        }

        public static async Task CreateTransaksi(string baseUrl, DataTransaksi transaksi)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(transaksi);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/DataTransaksi", content);
                    response.EnsureSuccessStatusCode(); // Throw if not a success code
                    Console.WriteLine($"Transaksi berhasil ditambahkan dengan ID {transaksi.idTransaksi}.");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static async Task DeleteTransaksi(string baseUrl, int idTransaksi)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Mengonstruksi URL dengan parameter idTransaksi
                    HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/DataTransaksi/{idTransaksi}");
                    response.EnsureSuccessStatusCode(); // Memastikan kode respons adalah kode sukses

                    Console.WriteLine($"Transaksi with ID {idTransaksi} deleted successfully.");
                }
                catch (HttpRequestException ex)
                {
                    // Mencetak pesan error jika terjadi kesalahan dalam request HTTP
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
