using Microsoft.AspNetCore.Mvc;
using SampleRestAPI.Context;

namespace SampleRestAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        readonly BookContext _bookContext;
        public BookController(BookContext bookContext) {
            _bookContext = bookContext;
        }

        [Route("id/{ids}")]
        [HttpGet]
        public IActionResult GetBooks(long ids)
        {
            List<Model.Book> books = new List<Model.Book>()
            {
               new Model.Book{ 
                 BookName = "Check",
                 Id = 99
               },

                new Model.Book{
                 BookName = "oombu",
                 Id = 9
               }
            };

            List<Model.Book> books2 = _bookContext.Books.ToList();
            return Ok(books2);
        }
    }
}
