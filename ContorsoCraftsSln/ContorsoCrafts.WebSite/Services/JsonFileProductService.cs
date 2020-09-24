using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContorsoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

//Service wich gets the json db file and deserializes it to the projec on model class

namespace ContorsoCrafts.WebSite.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        //search for Json file defined by name on specified rootpath folder
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "product.json"); }
        }

        //Json deserialization method into an enumerable list into product model class
        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}