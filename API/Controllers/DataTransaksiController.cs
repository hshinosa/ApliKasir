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
        private static string jsonFilePath = "C:\\Users\\fadillah\\OneDrive - Telkom University\\Dokumen\\My File\\RPL\\SEMESTER 4\\Kontruksi Perangkat Lunak\\ApliKasir\\ApliKasir\\Transaksi.json";
        private static List<transaksi> transaksi = InitializeDataFromJson(jsonFilePath);

        private static List<transaksi> InitializeDataFromJson(string jsonFilePath)
        {
            List<transaksi> data = new List<transaksi>();
            if (System.IO.File.Exists(jsonFilePath))
            {
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                data = JsonConvert.DeserializeObject<List<transaksi>>(jsonData);
            }
            return data;
        }

        private static void SaveDataToJsonFile(List<transaksi> data)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, jsonData);
        }

        [HttpGet]
        public IEnumerable<transaksi> Get()
        {
            return transaksi;
        }

        [HttpPost]
        public IActionResult Post([FromBody] transaksi newvalue)
        {
            transaksi.Add(newvalue);
            SaveDataToJsonFile(transaksi);
            return Ok(); // Return 200 OK status
        }

        [HttpGet("{id}")]
        public ActionResult<transaksi> Get(int id)
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
