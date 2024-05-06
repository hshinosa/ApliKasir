using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataTransaksiController : ControllerBase
    {
        private static string jsonFilePath = "C:\\Kuliah\\Coding\\C#\\Aplikasir\\ApliKasir\\json\\transaksi.json";
        private static List<DataTransaksi> transaksi = InitializeDataFromJson(jsonFilePath);

        private static List<DataTransaksi> InitializeDataFromJson(string jsonFilePath)
        {
            List<DataTransaksi> data = new List<DataTransaksi>();
            if (System.IO.File.Exists(jsonFilePath))
            {
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                data = JsonConvert.DeserializeObject<List<DataTransaksi>>(jsonData);
            }
            return data;
        }

        private static void SaveDataToJsonFile(List<DataTransaksi> data)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, jsonData);
        }

        [HttpGet]
        public IEnumerable<DataTransaksi> Get()
        {
            return transaksi;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DataTransaksi newvalue)
        {
            transaksi.Add(newvalue);
            SaveDataToJsonFile(transaksi);
            return Ok(); // Return 200 OK status
        }

        [HttpGet("{id}")]
        public ActionResult<DataTransaksi> Get(int id)
        {
            if (id < 0 || id >= transaksi.Count)
            {
                return NotFound(); // Return 404 Not Found status if ID is out of range
            }
            return transaksi[id];
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= transaksi.Count)
            {
                return NotFound(); // Return 404 Not Found status if ID is out of range
            }
            transaksi.RemoveAt(id);
            SaveDataToJsonFile(transaksi);
            return NoContent(); // Return 204 No Content status
        }
    }
}
