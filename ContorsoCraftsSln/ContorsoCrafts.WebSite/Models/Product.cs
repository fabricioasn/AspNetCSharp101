using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ContorsoCrafts.WebSite.Models
{
    public class Product
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int[] Ratings { get; set; }
   

    //overriding tostrigng to serialize JSON into object
    public override string ToString() =>    
        //serialize product strings back to JSON
        JsonSerializer.Serialize<Product>(this);

    }
}
