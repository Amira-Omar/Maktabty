using Maktabty.Models;
using Maktabty.Repositories;
using Maktabty.viewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Maktabty.Controllers
{
    public class AdminController : Controller
    {
       
        IAdminRepository adminRepository;
        
        public AdminController(IAdminRepository admRepo)
        {
            this.adminRepository = admRepo;
        }

        public IActionResult Books()
        {
           
            List<Book> books = adminRepository.getAllBooks();
          
            return View("Books",books);
        }
        public  IActionResult BookDetails(int id)
        {
            Book book = adminRepository.getBookById(id);
            
            return View("BookDetails",book);
        }
        public IActionResult DeleteBook(int id)
        {
            int numOfDeletd = adminRepository.deleteBook(id);
            return RedirectToAction("Books");           
        }

        [HttpGet]
        public IActionResult NewBook()
        {
            List<Category> Cats = adminRepository.getAllCategories();
            ViewData["Cats"] = Cats;
            List<Author> Authors = adminRepository.getAllAuthors();
            ViewData["Authors"] = Authors;
            return View("NewBook",new Book());
        }

        [HttpPost]
        public IActionResult SaveNewBook(Book newBook)
        {
            if(ModelState.IsValid)
            {
                adminRepository.insertBook(newBook);
                return RedirectToAction("Books");
            }
            List<Book> books = adminRepository.getAllBooks();
            ViewData["books"] = books;
            return View(newBook);
        }

        [HttpGet]
        public IActionResult EditBook(int id)
        {
            Book bookSample = adminRepository.getBookById(id);
            List<Category> Cats = adminRepository.getAllCategories();
            ViewData["Cats"] = Cats;
            List<Author> Authors = adminRepository.getAllAuthors();
            ViewData["Authors"] = Authors;
            return View("EditBook", bookSample);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEditBook(int id, Book bookView)
        {
            //if (crsView.Name != null)
            if (ModelState.IsValid)
            {
                adminRepository.updateBook(id, bookView);

                return RedirectToAction("Books");
            }
            
            return View("EditBook", bookView);
        }

        public IActionResult getBooksByCategory(int categId)
        {
            List<Book> bookList = adminRepository.getBooksByCategoryId(categId);
            return View(bookList);
        }
        public IActionResult Categories()
        {
            List<Category> cats = adminRepository.getAllCategories();
            
            return View("Categories",cats);
        }

        [HttpGet]
        public IActionResult NewCategory()
        {
            List<Category> Cats = adminRepository.getAllCategories();
            ViewData["Cats"] = Cats;
            return View("NewCategory", new Category());
        }

        [HttpPost]
        public IActionResult SaveNewCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                adminRepository.insertCategory(newCategory);
                return RedirectToAction("Category");
            }
            List<Category> category  = adminRepository.getAllCategories();
            ViewData["category"] = category;
            return View(newCategory);
        }


        public IActionResult Authors()
        {
            List<Author> authors = adminRepository.getAllAuthors();

            return View("Authors", authors);
        }

        public IActionResult DeleteAuthor(int id)
        {
            int numOfDeletd = adminRepository.deleteAuthor(id);
            return RedirectToAction("Authors");
        }

        [HttpGet]
        public IActionResult NewAuthor()
        {
            List<Author> Authors = adminRepository.getAllAuthors();
            ViewData["Authors"] = Authors;
            return View("NewAuthor", new Author());
        }

        [HttpPost]
        public IActionResult SaveNewAuthor(Author newAuthor)
        {
            if (ModelState.IsValid)
            {
                adminRepository.insertAuthor(newAuthor);
                return RedirectToAction("Authors");
            }
            List<Author> authors = adminRepository.getAllAuthors();
            ViewData["Authors"] = authors;
            return View(newAuthor);
        }

        public IActionResult Users()
        {
            List<ApplicationUser> users = adminRepository.getAllUsers();

            return View("Users", users);
        }

    }
}
