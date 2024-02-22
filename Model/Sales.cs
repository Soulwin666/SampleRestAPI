using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRestAPI.Model
{
    [Table("SALES")]
    public class Sales
    {
        [Column("SALES_ID"),JsonProperty("salesId")]
        public long salesId { get; set; }

        [Column("BOOK_ID"), JsonProperty("bookId")]
        public long BookId { get; set; }

        [Column("SALES_DATE"), JsonProperty("salesDate")]
        public DateTime SalesDate { get; set; }
    }
}
