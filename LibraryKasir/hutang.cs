using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static LibraryKasir.barang;

namespace LibraryKasir
{
    public static class hutang
    {
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
    }
}
