using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenericLibrary
{
    public static class GenericClass<T>
    {
        public static async Task CreateItem(string baseUrl, string endpointName, T item)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(item);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/{endpointName}", content);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine($"{typeof(T).Name} berhasil ditambahkan dengan ID {GetIdProperty(item)}.");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static async Task DeleteItem(string baseUrl, string endpointName, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/{endpointName}/{id}");
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine($"{typeof(T).Name} with ID {id} deleted successfully.");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error deleting {typeof(T).Name}: {ex.Message}");
                }
            }
        }

        private static object GetIdProperty(T item)
        {
            var properties = typeof(T).GetProperties();
            var idProperty = properties.FirstOrDefault(p => p.Name.ToLower().Contains("id"));
            if (idProperty != null)
            {
                return idProperty.GetValue(item);
            }
            return null;
        }
    }
}
