using System.Text.Json;
using System.Text.Json.Serialization;
namespace urlShortner.models

{
    public class Url
    {
        public string LongUrl{get; set;}
        public string ShortUrl{get; set;}
    }
}