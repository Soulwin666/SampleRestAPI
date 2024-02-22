using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRestAPI.Model
{
    [Table("BOOK")]
    public class Book
    {
        [JsonProperty("bookId"), Column("BOOK_ID")]
        public long Id { get; set; }

        [JsonProperty("bookName"), Column("BOOK_NAME")]
        public string? BookName { get; set; }
    }
}