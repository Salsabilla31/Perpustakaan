using PerpustakaanAPP.Api.Areas.Book.Models.Request;
using PerpustakaanAPP.Api.Areas.Book.Models.Resposes;
using PerpustakaanAPP.Api.Areas.Book.Outputs;
using PerpustakaanAPP.Data.Access.Models;
using System.Collections.Generic;

namespace PerpustakaanAPP.Api.Areas.Book.Services
{
    public class BookService
    {
        private readonly DataContext dataContext;

        public BookService(DataContext datacontext)
        {
            this.dataContext = datacontext;
        }
        public async Task<BookResponsesDTO> AddAsync(BookRequestDTO req)
        {
            var book = new Books
            {
                Bookname = req.Bookname,
                Description = req.Description,
                Author = req.Author,
                Publisher = req.Publisher,
                Releasedate = req.Releasedate,
                Pagebook = req.Pagebook
            };
            dataContext.Add(book);
            await dataContext.SaveChangesAsync();
            return new BookResponsesDTO()
            {
                Bookid = book.Bookid,
                Bookname = book.Bookname,
                Description = book.Description,
                Author = book.Author,
                Publisher = book.Publisher,
                Releasedate = book.Releasedate,
                Pagebook = book.Pagebook
            };
        }

        public async Task<BookResponsesDTO?> UpdateAsync(int id, BookRequestDTO req)
        {
            var book = await dataContext.Books.FindAsync(id);
            if (book == null)
            {
                return null;
            }
            book.Bookname = req.Bookname;
            book.Description = req.Description;
            book.Author = req.Author;
            book.Publisher = req.Publisher;
            book.Releasedate = req.Releasedate;
            book.Pagebook = req.Pagebook;
            await dataContext.SaveChangesAsync();
            return new BookResponsesDTO
            {
                Bookid = book.Bookid,
                Bookname = book.Bookname,
                Description = book.Description,
                Author = book.Author,
                Publisher = book.Publisher,
                Releasedate = book.Releasedate,
                Pagebook = book.Pagebook
            };
        }

        public async Task<BookResponsesDTO?> DeleteAsync(int id)
        {
            var book = await dataContext.Books.FindAsync(id);

            if (book == null)
            {
                return null; 
            }

            dataContext.Books.Remove(book);
            await dataContext.SaveChangesAsync();
            return new BookResponsesDTO
            {
                Bookid = book.Bookid,
                Bookname = book.Bookname,
                Description = book.Description,
                Author = book.Author,
                Publisher = book.Publisher,
                Releasedate = book.Releasedate,
                Pagebook = book.Pagebook
            };
        }


    }
}