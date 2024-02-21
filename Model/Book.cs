using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SampleRestAPI.Model
{
    [Table("BOOK")]
    public class Book
    {
        [JsonProperty("bookId"),Column("BOOK_ID")]
        public long Id { get; set; }

        [JsonProperty("bookName"), Column("BOOK_NAME")]
        public string? BookName { get; set; }
    }
}
