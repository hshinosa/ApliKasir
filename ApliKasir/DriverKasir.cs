using ApliKasir;
using System.Net.Http.Json;
using System.Text.Json;

internal class Program
{
    static async Task Main(string[] args)
    {
        String namaBarang;
        int idBarang, jumlahBarang;
        double hargaBarang;

        // Base URL of your API
        string baseUrl = "https://localhost:7058";

        // Example of GET request to retrieve all DataBarang
        await GetData(baseUrl);

        Console.Write("Masukkan ID Barang : ");
        idBarang = Convert.ToInt32(Console.ReadLine());
        Console.Write("Masukkan Nama Barang : ");
        namaBarang = Console.ReadLine();
        Console.Write("Masukkan Harga Barang : ");
        hargaBarang = Convert.ToDouble(Console.ReadLine());
        Console.Write("Masukkan Jumlah Barang : ");
        jumlahBarang = Convert.ToInt32(Console.ReadLine());
        // Example of POST request to add a new DataBarang
        await AddData(baseUrl,idBarang,namaBarang,hargaBarang,jumlahBarang);

        // Example of DELETE request to remove a DataBarang
        //await DeleteData(baseUrl, 0); // Pass the ID of the item to delete
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