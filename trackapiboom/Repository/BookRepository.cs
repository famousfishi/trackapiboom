using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using trackapiboom.Data;
using trackapiboom.DTOs;
using trackapiboom.Models;
using trackapiboom.Repository.InterfaceServiceTypes;

namespace trackapiboom.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            //List<BookDTO> bookRecords = await _context.Books.Select(bookModel => new BookDTO
            //{
            //    Id = bookModel.Id,
            //    Title = bookModel.Title,
            //    Description = bookModel.Description
            //}).ToListAsync();

            //return bookRecords;

            List<Books> book = await _context.Books.ToListAsync();

            List<BookDTO> bookRecords = _mapper.Map<List<BookDTO>>(book);

            return bookRecords;
        }

        public async Task<BookDTO> GetBookByIdAsync(int bookId)
        {
            //BookDTO bookRecord = await _context.Books.Where(book => book.Id == bookId).Select(bookModel => new BookDTO
            //{
            //    Id = bookModel.Id,
            //    Title = bookModel.Title,
            //    Description = bookModel.Description
            //}).FirstOrDefaultAsync();

            //return bookRecord;

            Books book = await _context.Books.FindAsync(bookId);

            BookDTO bookRecord = _mapper.Map<BookDTO>(book);

            return bookRecord;
        }

        public async Task<int> AddBooksAsync(BookDTO bookDTO)
        {
            Books book = new()
            {
                Title = bookDTO.Title,
                Description = bookDTO.Description,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task UpdateBookByIdAsync(int bookId, BookDTO bookDTO)
        {
            //Books book = await _context.Books.FindAsync(bookId);

            //if (book != null)
            //{
            //    book.Title = bookDTO.Title;
            //    book.Description = bookDTO.Description;
            //    book.DateUpdated = DateTime.UtcNow;

            //    await _context.SaveChangesAsync();
            //}

            Books book = new()
            {
                Id = bookId,
                Title = bookDTO.Title,
                Description = bookDTO.Description,
                DateUpdated = DateTime.UtcNow,
                DateCreated = DateTime.UtcNow,
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            Books book = new()
            {
                Id = bookId
            };

            if (book != null)
            {
                _context.Books.Remove(book);

                await _context.SaveChangesAsync();
            }
        }
    }
}