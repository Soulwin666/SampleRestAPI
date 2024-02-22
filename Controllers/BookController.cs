using Microsoft.AspNetCore.Mvc;

namespace SampleRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase, IBook
    {
        private readonly Service.Book _bookService;

        public BookController(Service.Book bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// get books without params
        /// </summary>
        /// <returns></returns>
        [Route("getBooks")]
        [HttpGet]
        public IActionResult GetBooksWithoutParams()
        {
            try
            {
                List<Model.Book> books = _bookService.GetBooksWithoutParams();
                return Ok(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// get books with params
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("bookId/{id}")]
        public IActionResult GetBooksWithParams(long id)
        {
            try
            {
                try
                {
                    Model.Book books = _bookService.GetBooksWithParams(id);
                    return Ok(books);
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// create books
        /// </summary>
        /// <param name="book"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        [HttpPost]
        [Route("createBook")]
        public IActionResult CreateBooks([FromBody] List<Model.Book> book)
        {
            try
            {
                this._bookService.CreateBooks(book);
                return Ok("books is created");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateBook")]
        public IActionResult UpdateBooks([FromBody] List<Model.Book> book)
        {
            try
            {
                this._bookService.UpdateBooks(book);
                return Ok("books are updated");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteBook")]
        public IActionResult DeleteBook([FromBody] List<long> book)
        {
            try
            {
                this._bookService.DeleteBooks(book);
                return Ok("books are deleted");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}