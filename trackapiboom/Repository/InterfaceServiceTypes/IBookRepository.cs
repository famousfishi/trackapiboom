using System.Collections.Generic;
using System.Threading.Tasks;
using trackapiboom.DTOs;

namespace trackapiboom.Repository.InterfaceServiceTypes
{
    public interface IBookRepository
    {
        Task<List<BookDTO>> GetAllBooksAsync();

        Task<BookDTO> GetBookByIdAsync(int bookId);

        Task<int> AddBooksAsync(BookDTO bookDTO);

        Task UpdateBookByIdAsync(int bookId, BookDTO bookDTO);

        Task DeleteBook(int bookId);
    }
}