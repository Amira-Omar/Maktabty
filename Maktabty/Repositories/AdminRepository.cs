using Maktabty.Models;
using Maktabty.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Maktabty.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        DbEntities db;
        public AdminRepository(DbEntities _db)
        {
            db = _db;
        }
        #region Book Operations
        public int deleteBook(int id)
        {
            Book book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                db.Books.Remove(book);
                return db.SaveChanges();
            }

            return 0;
        }
        public List<Book> getAllBooks()
        {
            List<Book> books = db.Books.Include(b => b.Category).Include(b => b.authors).ToList();
            return books;
        }

        public List<Book> getBooksByCategoryId(int categId)
        {
            return db.Books.Where(b => b.CategoryId == categId).ToList();
        }

        public Book getBookById(int id)
        {
             return db.Books.Include(b => b.Category).Include(b => b.authors).SingleOrDefault(b => b.Id == id);
        }

        public int insertBook(Book book)
        {
            db.Books.Add(book);
            return db.SaveChanges();
        }

        public int updateBook(int id, Book book)
        {
            Book oldBooks = db.Books.FirstOrDefault(b => b.Id == id);

            if (oldBooks != null)
            {
                oldBooks.Id = book.Id;
                oldBooks.Name = book.Name;
                oldBooks.Image = book.Image;
                oldBooks.IsFeatured = book.IsFeatured;
                oldBooks.Language = book.Language;
                oldBooks.Description = book.Description;
                oldBooks.Pages = book.Pages;
                oldBooks.NumOfDownloads = book.NumOfDownloads;
                oldBooks.CategoryId = book.CategoryId;
                oldBooks.Category = book.Category;
                oldBooks.authors = book.authors;
                return db.SaveChanges();
            }
            return 0;
        }
        #endregion
        #region Author Operations
        public int deleteAuthor(int id)
        {
            Author author = db.Authors.FirstOrDefault(b => b.Id == id);
            if (author != null)
            {
                db.Authors.Remove(author);
                return db.SaveChanges();
            }

            return 0;
        }

        public List<Author> getAllAuthors()
        {
            return db.Authors.ToList();
        }

        public Author getAuthorById(int id)
        {
            return db.Authors.FirstOrDefault(a => a.Id == id);
        }

        public int insertAuthor(Author author)
        {
            db.Authors.Add(author);
            return db.SaveChanges();
        }

        public int updateAuthor(int id, Author author)
        {
            Author oldAuthor = db.Authors.FirstOrDefault(a => a.Id == id);
            if(oldAuthor != null)
            {
                oldAuthor.Name = author.Name;
                oldAuthor.Image = author.Image;
                return db.SaveChanges();
            }
            return 0;
        }
        #endregion
        #region User Operations
        public List<ApplicationUser> getAllUsers()
        {
            return db.Users.ToList();
        }
        public ApplicationUser getUserById(string id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
        #endregion
        #region Category Operations
        public List<Category> getAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category getCategoryById(int id)
        {
            return db.Categories.FirstOrDefault(c=>c.Id == id);
        }

        public int insertCategory(Category category)
        {
            db.Categories.Add(category);
            return db.SaveChanges();
        }

        public int updateCategory(int id, Category category)
        {
            Category oldCat = db.Categories.FirstOrDefault(c=>c.Id == id);
            if(oldCat != null)
            {
                oldCat.Name = category.Name;
                return db.SaveChanges();
            }
            return 0;
        }
        #endregion

       

    }
}
