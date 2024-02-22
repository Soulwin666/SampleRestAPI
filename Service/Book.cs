using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace SampleRestAPI.Service
{
    public class Book
    {
        private readonly Repository.Book _bookRepository;

        public Book(Repository.Book bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// get books without param
        /// </summary>
        /// <returns></returns>
        public List<Model.Book> GetBooksWithoutParams()
        {
            try
            {
                List<Model.Book> books = _bookRepository.GetBooksWithoutParams();
                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
                Model.Book books = _bookRepository.GetBooksWithParams(bookId);

                if (books == null)
                {
                    throw new KeyNotFoundException("details not found");
                }

                return books;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
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
                if (book.IsNullOrEmpty())
                {
                    throw new KeyNotFoundException("details not found");
                }

                this._bookRepository.CreateBooks(book);
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
        public void UpdateBooks(List<Model.Book> book)
        {
            try
            {
                if (book.IsNullOrEmpty())
                {
                    throw new KeyNotFoundException("details not found");
                }

                this._bookRepository.UpdateBook(book);
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
        public void DeleteBooks(List<long> book)
        {
            try
            {
                if (book.IsNullOrEmpty())
                {
                    throw new KeyNotFoundException("details not found");
                }

                this._bookRepository.DeleteBook(book);
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
        /// <returns></returns>
        public List<Model.Book> GetSalesBooks()
        {
            try
            {
                List<Model.Book> books = this._bookRepository.GetSalesBooks();
                return books;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}