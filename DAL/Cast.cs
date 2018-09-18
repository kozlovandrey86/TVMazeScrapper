using Newtonsoft.Json;
using System;

namespace DAL
{
    [JsonObject("person")]
    public class Cast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        
        public int ShowId { get; set; }
    }
}