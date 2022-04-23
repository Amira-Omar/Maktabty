using Maktabty.Models;
using System.Collections.Generic;

namespace Maktabty.Repositories
{
    public interface IAdminRepository
    {
        int deleteBook(int id);
        List<Book> getAllBooks();
        Book getBookById(int id);
        List<Book> getBooksByCategoryId(int categId);
        int insertBook(Book book);
        int updateBook(int id, Book book);
        int deleteAuthor(int id);
        List<Author> getAllAuthors();
        Author getAuthorById(int id);
        int insertAuthor(Author author);
        int updateAuthor(int id, Author author);
        List<ApplicationUser> getAllUsers();
        ApplicationUser getUserById(string id);
        List<Category> getAllCategories();
        Category getCategoryById(int id);
        int insertCategory(Category category);
        int updateCategory(int id, Category category);
       
        
    }
}
