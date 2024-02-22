using Microsoft.EntityFrameworkCore;
using SampleRestAPI.Context;

namespace SampleRestAPI.Repository
{
    public class Book
    {
        private readonly MyDbContext _bookContext;

        public Book(MyDbContext bookContext)
        {
            _bookContext = bookContext;
        }

        /// <summary>
        /// get books without param
        /// </summary>
        /// <returns></returns>
        public List<Model.Book> GetBooksWithoutParams()
        {
            try
            {
                List<Model.Book> books = _bookContext.Books.ToList();

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

        /// <summary>
        /// get books with param
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public Model.Book GetBooksWithParams(long bookId)
        {
            try
            {
                Model.Book books = _bookContext.Books.Where(x => x.Id == bookId).FirstOrDefault();

                return books;
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
        public void CreateBooks(List<Model.Book> book)
        {
            try
            {
                book.ForEach(b =>
                {
                    Model.Book book = new Model.Book() { BookName = b.BookName };
                    _bookContext.Books.Add(book);
                });

                _bookContext.SaveChanges();
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
        /// <exception cref="KeyNotFoundException"></exception>
        public void UpdateBook(List<Model.Book> book)
        {
            try
            {
                book.ForEach(b =>
                {
                    Model.Book book = _bookContext.Books.Find(b.Id);
                    if (book is null)
                    {
                        throw new KeyNotFoundException("book details not found");
                    }

                    book.BookName = b.BookName;
                });

                _bookContext.SaveChanges();
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
        /// <exception cref="KeyNotFoundException"></exception>
        public void DeleteBook(List<long> book)
        {
            try
            {
                book.ForEach(b =>
                {
                    Model.Book book = _bookContext.Books.Find(b);

                    if (book is null)
                    {
                        throw new KeyNotFoundException("book details not found");
                    }

                    _bookContext.Books.Remove(book);

                    _bookContext.Entry(book).State = EntityState.Deleted;
                });

                _bookContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}