using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

//product model class

namespace ContorsoCrafts.WebSite.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        public int[] Ratings { get; set; }
   

    //overriding tostrigng to serialize JSON into object
    public override string ToString() =>    
        //serialize product strings back to JSON
        JsonSerializer.Serialize<Product>(this);

    }
}
