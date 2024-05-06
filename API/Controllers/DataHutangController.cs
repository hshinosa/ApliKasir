using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    
        [ApiController]
        [Route("[controller]")]
        public class DataHutangController : ControllerBase
        {
            private static string jsonFilePath = "C:\\Kuliah\\Coding\\C#\\Aplikasir\\ApliKasir\\json\\hutang.json";
            private static List<DataHutang> dataHutang = InitializeDataFromJson(jsonFilePath);

            private static List<DataHutang> InitializeDataFromJson(string jsonFilePath)
            {
                List<DataHutang> data = new List<DataHutang>();
                if (System.IO.File.Exists(jsonFilePath))
                {
                    string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                    data = JsonConvert.DeserializeObject<List<DataHutang>>(jsonData);
                }
                return data;
            }

            private static void SaveDataToJsonFile(List<DataHutang> data)
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, jsonData);
            }

            [HttpGet]
            public IEnumerable<DataHutang> Get()
            {
                return dataHutang;
            }

            [HttpPost]
            public IActionResult Post([FromBody] DataHutang newValue)
            {
                dataHutang.Add(newValue);
                SaveDataToJsonFile(dataHutang);
                return Ok();
            }

            [HttpGet("{id}")]
            public ActionResult<DataHutang> Get(int id)
            {
                if (id < 0 || id >= dataHutang.Count)
                {
                    return NotFound();
                }

                return dataHutang[id];
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                if (id < 0 || id >= dataHutang.Count)
                {
                    return NotFound();
                }

                dataHutang.RemoveAt(id);
                SaveDataToJsonFile(dataHutang);
                return NoContent();
            }
        }
    }

