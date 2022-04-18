using Maktabty.Models;
using Maktabty.Repositories;
using Maktabty.viewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Maktabty.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;
        ICategoryRepository CategoryRepository;
        IAuthorRepository AuthorRepository;
        public BookController(IBookRepository bookRepository, ICategoryRepository CategoryRepository
            , IAuthorRepository AuthorRepository)
        {
            this.bookRepository = bookRepository;
            this.CategoryRepository = CategoryRepository;
            this.AuthorRepository = AuthorRepository;
        }
        public IActionResult Index()
        {
            BookVM model = new BookVM
            {
                Book = bookRepository.getAllWithCategoryAndAuthors(),
                Author=AuthorRepository.getAll(),
                Category=CategoryRepository.getAll(),
            };
            
            return View(model);
        }
        public IActionResult GetBooksByCategory(int categoryId)
        {
            List<Book> bookList = bookRepository.getByCategory(categoryId);
            return PartialView("_BookByCategoryListPartial", bookList);
        }
        public IActionResult GetBooksByAuthors(int authorId)
        {
           
            BookVM model = new BookVM
            {
                Book= bookRepository.getByAuthor(authorId)
            };
            return PartialView("_BookByAuthorListPartial", model);
        }
        public IActionResult GetBookByName(string bookName)
        {


            List<Book> book = bookRepository.getByName(bookName);

            return PartialView("_BookByNameListPartial", book);
        }
        public IActionResult Details(int id)
        {
            Book book = bookRepository.getById(id);
            return View(book);
        }

    }
}
