using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBarangController : ControllerBase
    {
        private static string jsonFilePath = "C:\\Users\\fadillah\\OneDrive - Telkom University\\Dokumen\\My File\\RPL\\SEMESTER 4\\Kontruksi Perangkat Lunak\\ApliKasir\\json\\barang.json";
        private static List<DataBarang> databarang = InitializeDataFromJson(jsonFilePath);

        private static List<DataBarang> InitializeDataFromJson(string jsonFilePath)
        {
            List<DataBarang> data = new List<DataBarang>();
            if (System.IO.File.Exists(jsonFilePath))
            {
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                data = JsonConvert.DeserializeObject<List<DataBarang>>(jsonData);
            }
            return data;
        }

        private static void SaveDataToJsonFile(List<DataBarang> data)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, jsonData);
        }

        [HttpGet]
        public IEnumerable<DataBarang> Get()
        {
            return databarang;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DataBarang newvalue)
        {
            databarang.Add(newvalue);
            SaveDataToJsonFile(databarang);
            return Ok(); // Return 200 OK status
        }

        [HttpGet("{id}")]
        public ActionResult<DataBarang> Get(int id)
        {
            if (id < 0 || id >= databarang.Count)
            {
                return NotFound(); // Return 404 Not Found status if ID is out of range
            }
            return databarang[id];
        }

        [HttpDelete("{idBarang}")]
        public IActionResult Delete(int idBarang)
        {
            var item = databarang.FirstOrDefault(b => b.idBarang == idBarang);

            if (item == null)
            {
                return NotFound();
            }

            databarang.Remove(item);
            SaveDataToJsonFile(databarang);
            return NoContent();
        }
    }
}
