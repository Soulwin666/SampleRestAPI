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

        /// <summary>
        ///
        /// </summary>
        public List<Model.Book> GetSalesBooks()
        {
            try
            {
                List<Model.Book> book = _bookContext.Books.ToList();
                List<Model.Sales> sales = _bookContext.Sales.ToList();

                var query = from b in book
                            join s in sales on b.Id equals s.BookId
                            group new { b, s } by new { b.BookName } into g
                            select new Model.Book
                            {
                                BookName = g.Key.BookName,
                                //It use to get the max item from the grouped elements
                                Id = g.Max(item => item.b.Id)
                            };
                if (!(query.Count() > 0))
                {
                    throw new KeyNotFoundException("data not found");
                }

                List<Model.Book> books = query.ToList();

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// left join example
        /// </summary>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public List<long> GetSalesBookss()
        {
            try
            {
                var query = from b in _bookContext.Books
                            join s in _bookContext.Sales on b.Id equals s.BookId into bookSales
                            from s in bookSales.DefaultIfEmpty()
                            where s == null
                            select b.Id;

                if (!(query.Count() > 0))
                {
                    throw new KeyNotFoundException("data not found");
                }

                List<long> books = query.ToList();

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}