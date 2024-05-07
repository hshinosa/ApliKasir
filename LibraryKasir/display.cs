using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryKasir
{
    public static class display
    {
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

    }
}
