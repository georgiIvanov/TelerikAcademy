using LibrarySystem.Models;
using LibrarySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.Utilities
{
    public static class ConvertToViewModel
    {
        public static IQueryable<BookViewModel> ConvertToBookViewModel(this IQueryable<Book> Books)
        {
            var converted = Books.Select(b => new BookViewModel
            {
                Id = b.Id,
                Description = b.Description,
                Author = b.Author,
                CategoryName = b.Category.Name,
                ISBN = b.ISBN,
                Title = b.Title,
                Website = b.Website
            });

            return converted;
        }

        public static Book ConvertToBook(this BookViewModel book)
        {
            var converted = new Book()
            {
                Id = book.Id,
                Description = book.Description,
                Author = book.Author,
                
                ISBN = book.ISBN,
                Title = book.Title,
                Website = book.Website
            };

            return converted;
        }

        public static IQueryable<CategoryViewModel> ConvertToCategoryViewModel(this IQueryable<Category> Categories)
        {
            var converted = Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });

            return converted;
        }
        
    }
}