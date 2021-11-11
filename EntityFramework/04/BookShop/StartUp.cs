namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(RemoveBooks(db));
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(c => c.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();
            
            return books.Count;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(d => d.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }


        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryBooks = context.Categories
                .Select(category => new
                {
                    CatName = category.Name,
                    Books = category.CategoryBooks.Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate.Value
                    })
                    .OrderByDescending(b => b.Value)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(x => x.CatName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var category in categoryBooks)
            {
                sb.AppendLine($"--{category.CatName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(category => new
                {
                    category.Name,
                    Profit = category.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(p => p.Profit)
                .ThenBy(x => x.Name)
                .ToArray();

            var result = string.Join(Environment.NewLine, categories
               .Select(category => $"{category.Name} ${category.Profit:F2}"));

            return result;

        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(author => new
                {
                    author.FirstName,
                    author.LastName,
                    TotalCopies = author.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(t => t.TotalCopies)
                .ToArray();

            var result = string.Join(Environment.NewLine, authors
                .Select(author => $"{author.FirstName} {author.LastName} - {author.TotalCopies}"));
           
            return result;
        }


        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                                .Where(book => EF.Functions.Like(book.Author.LastName, $"{input}%"))
                                .Select(book => new
                                {
                                    book.Title,
                                    AuthorName = book.Author.FirstName + " " + book.Author.LastName,
                                    book.BookId
                                })
                                .OrderBy(books => books.BookId)
                                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(book => $"{book.Title} ({book.AuthorName})"));
            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                                  .Where(author => EF.Functions.Like(author.FirstName, $"%{input}"))
                                  .Select(au => new
                                  {
                                      au.FirstName,
                                      au.LastName
                                  })
                                  .OrderBy(x => x.FirstName)
                                  .ThenBy(x => x.LastName)
                                  .ToArray();

            var result = string.Join(Environment.NewLine, authors.Select(a => $"{a.FirstName} {a.LastName}"));
            return result;

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                                .Where(book => book.ReleaseDate.Value < targetDate)
                                .Select(book => new
                                {
                                    book.Title,
                                    book.EditionType,
                                    book.Price,
                                    book.ReleaseDate.Value
                                })
                                .OrderByDescending(book => book.Value)
                                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));
            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => x.ToLower())
                                    .ToArray();

            var books = context.Books
                                .Include(x => x.BookCategories)
                                .ThenInclude(x => x.Category)
                                .ToArray()
                                .Where(book => book.BookCategories
                                     .Any(category => categories.Contains(category.Category.Name.ToLower())))
                                 .Select(books => books.Title)
                                 .OrderBy(title => title)
                                 .ToArray();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                                .Where(book => book.ReleaseDate.Value.Year != year)
                                .Select(book => new
                                {
                                    book.Title,
                                    book.BookId
                                })
                                .OrderBy(book => book.BookId)
                                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));
            return result;
        }


        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                                .Where(books => books.Price > 40)
                                .Select(books => new
                                {
                                    books.Title,
                                    books.Price
                                })
                                .OrderByDescending(books => books.Price)
                                .ToArray();
            /*
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }
            return sb.ToString().TrimEnd();
            */

            var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:F2}"));
            return result;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                                .Where(books => books.AgeRestriction == ageRestriction)
                                .Select(book => book.Title)
                                .OrderBy(title => title)
                                .ToArray();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                                .Where(books => books.EditionType == EditionType.Gold &&
                                                                     books.Copies < 5000)
                                .Select(book => new
                                {
                                    book.BookId,
                                    book.Title,
                                })
                                .OrderBy(x => x.BookId)
                                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));
            return result;
        }
    }
}
