using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace Day03Lab_231230949_29_08_2025_2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public string? Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string? Sumary { get; set; }

        // danh sách các cuốn sách
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorID = 1,
                    GenreID = 1,
                    Image = "/image/b1.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 2,
                    Title = "Book 2",
                    AuthorID = 1,
                    GenreID = 1,
                    Image = "/image/b2.jpg",
                    Price = 40000,
                    Sumary = "",
                    TotalPage = 10
                },
                new Book()
                {
                    Id = 3,
                    Title = "Book 3",
                    AuthorID = 2,
                    GenreID = 3,
                    Image = "/image/b1.jpg",
                    Price = 1000000,
                    Sumary = "",
                    TotalPage = 200
                },
            };
            return books;

        }

        public Book? GetBookByID(int id)
        {
            Book? book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "1", Text = "Nam Cao"},
            new SelectListItem {Value = "2", Text = "Ngô Tất Tố"},
            new SelectListItem {Value = "3", Text = "Adamkhoom"},
            new SelectListItem {Value = "4", Text = "Thiền sư Thích Nhất Hạnh"}
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value ="1", Text="Truyện tranh"},
            new SelectListItem{Value ="2", Text="Văn học đương đại"},
            new SelectListItem{Value ="3", Text="Phật học phổ thông"},
            new SelectListItem{Value ="4", Text="Truyện cười"},
        };


    }
}
