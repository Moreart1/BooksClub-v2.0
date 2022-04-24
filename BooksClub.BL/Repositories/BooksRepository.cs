using BooksClub.DAL;
using BooksClub.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksClub.BL.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly MyDbContext myDbContext;

        public BooksRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public async Task Add(ModelBooks entity)
        {
            entity.IsDelete = false;
            myDbContext.Add(entity);
            await myDbContext.SaveChangesAsync();
        }

        public async Task Delete(int BooksId)
        {
            var books = await myDbContext.Books.FirstOrDefaultAsync(en => en.Id == BooksId);
            books.IsDelete = true;
            await myDbContext.SaveChangesAsync();
        }
        public async Task Delete(ModelBooks books)
        {
            var booksAll = await myDbContext.Books.FirstOrDefaultAsync(en => en.Id == books.Id);
            booksAll.IsDelete = true;
            await myDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<ModelBooks>> Get()
        {
            var books = await myDbContext.Books.ToListAsync();
            return books;
        }

        public async Task Update(ModelBooks entity)
        {
            var books = await myDbContext.Books.FirstOrDefaultAsync(en => en.Id == entity.Id);
            books.Name = entity.Name;
            books.Year = entity.Year;
            books.Genre = entity.Genre;
            books.Author = entity.Author;
            books.IsDelete = entity.IsDelete;
            await myDbContext.SaveChangesAsync();
        }
    }
}
