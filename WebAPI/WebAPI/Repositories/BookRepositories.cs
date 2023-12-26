using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class BookRepositories : IBookRepositories
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepositories(BookStoreContext context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddBookAsync(BookModel model)
        {
            var newBook = _mapper.Map<Book>(model);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        async Task IBookRepositories.DeleteBookAsync(int id)
        {
            var deleteBook = _context.Books!.SingleOrDefault(m => m.Id == id);
            if (deleteBook != null)
            {
                _context.Books!.Remove(deleteBook);
                await _context.SaveChangesAsync(); 
            }
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var book = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookModel>>(book);
        }

        public async Task<BookModel> GetBookAsync(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        async Task IBookRepositories.UpdateBookAsync(int id, BookModel model)
        {
            if(id == model.Id)
            {
                var updateBook = _mapper.Map<Book>(model);  
                _context.Books!.Update(updateBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
