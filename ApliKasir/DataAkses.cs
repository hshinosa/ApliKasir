using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApliKasir
{
    public class DataAkses
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
                    var barang = dataBarang?.FirstOrDefault(b => b.namaBarang == namaBarang);

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

        public static async Task DisplayData(string baseUrl, string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{baseUrl}{endpoint}");
                    response.EnsureSuccessStatusCode(); // Throw if not a success code
                    string responseBody = await response.Content.ReadAsStringAsync();

                    switch (endpoint)
                    {
                        case "/DataBarang":
                            var dataBarang = JsonSerializer.Deserialize<List<DataBarang>>(responseBody);
                            Console.WriteLine($"{"ID Barang",-10} {"Nama Barang",-20} {"Harga Barang",-15} {"Jumlah Barang",-15}");
                            foreach (var barang in dataBarang)
                            {
                                Console.WriteLine($"{barang.idBarang,-10} {barang.namaBarang,-20} {barang.hargaBarang,-15:C} {barang.jumlahBarang,-15}");
                            }
                            break;

                        case "/DataTransaksi":
                            var dataTransaksi = JsonSerializer.Deserialize<List<DataTransaksi>>(responseBody);
                            Console.WriteLine($"{"ID Transaksi",-15} {"Nama Barang",-20} {"Jumlah Barang",-15} {"Total Harga",-15}");
                            foreach (var transaksi in dataTransaksi)
                            {
                                Console.WriteLine($"{transaksi.idTransaksi,-15} {transaksi.namaBarang,-20} {transaksi.jumlahBarang,-15} {transaksi.totalHarga,-15:C}");
                            }
                            break;

                        case "/DataHutang":
                            var dataHutang = JsonSerializer.Deserialize<List<DataHutang>>(responseBody);
                            Console.WriteLine($"{"ID Hutang",-15} {"Nama Barang",-20} {"Jumlah Barang",-15} {"Total Harga",-15}");
                            foreach (var hutang in dataHutang)
                            {
                                Console.WriteLine($"{hutang.idHutang,-15} {hutang.namaBarang,-20} {hutang.jumlahBarang,-15} {hutang.totalHarga,-15:C}");
                            }
                            break;
                        default:
                            Console.WriteLine(responseBody);
                            break;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static async Task CreateBarang(string baseUrl, DataBarang barang)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(barang);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/DataBarang", content);
                    response.EnsureSuccessStatusCode(); // Throw if not a success code
                    Console.WriteLine($"Barang berhasil ditambahkan dengan ID {barang.idBarang}.");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
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

        public static async Task CreateHutang(string baseUrl, DataHutang hutang)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(hutang);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/DataHutang", content);
                    response.EnsureSuccessStatusCode(); // Throw if not a success code
                    Console.WriteLine($"Hutang berhasil ditambahkan dengan ID {hutang.idHutang}.");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public static async Task DeleteBarang(string baseUrl, int idBarang)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Mengonstruksi URL dengan parameter idBarang
                    HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/DataBarang/{idBarang}");
                    response.EnsureSuccessStatusCode(); // Memastikan kode respons adalah kode sukses

                    Console.WriteLine($"Barang with ID {idBarang} deleted successfully.");
                }
                catch (HttpRequestException ex)
                {
                    // Mencetak pesan error jika terjadi kesalahan dalam request HTTP
                    Console.WriteLine($"Error deleting barang: {ex.Message}");
                }
            }
        }
        public static async Task DeleteHutang(string baseUrl, int idHutang)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Mengonstruksi URL dengan parameter idHutang
                    HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/DataHutang/{idHutang}");
                    response.EnsureSuccessStatusCode(); // Memastikan kode respons adalah kode sukses

                    Console.WriteLine($"Hutang with ID {idHutang} deleted successfully.");
                }
                catch (HttpRequestException ex)
                {
                    // Mencetak pesan error jika terjadi kesalahan dalam request HTTP
                    Console.WriteLine($"Error deleting hutang: {ex.Message}");
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