using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using practicaLinQ.Entities;

namespace practicaLinQ;

public class LinqQueries
{
    List<Book> listBooks = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string jsonSring = reader.ReadToEnd();
            this.listBooks = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(jsonSring, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? new List<Book>();
        }
    }

    public IEnumerable<Book> AllCollections()
    {
        return listBooks;
    }

    public IEnumerable<Book> Books2000()
    {
        try
        {
            return from book in listBooks where book.PublishedDate.Year > 2000 select book;
        }
        catch
        {
            return listBooks.Where(x => x.PublishedDate.Year > 2000);
        }

    }

    public IEnumerable<Book> BooksAndroid()
    {
        try
        {
            return from book in listBooks where book.Title.Contains("Android") select book;
        }
        catch
        {
            return listBooks.Where(x => x.Title.Contains("Android"));
        }
    }

    public IEnumerable<Book> BooksAndroid2010()
    {
        try
        {
            return from book in listBooks where book.Title.Contains("Android") && book.PublishedDate.Year > 2010 select book;
        }
        catch
        {
            return listBooks.Where(x => x.Title.Contains("Android") && x.PublishedDate.Year > 2010);
        }
    }

    public IEnumerable<Book> Books250Action()
    {
        try
        {
            return from book in listBooks where book.PageCount > 250 && book.Title.Contains("in Action") select book;
        }
        catch
        {
            return listBooks.Where(x => x.PageCount > 250 && x.Title.Contains("in Action"));
        }
    }

    public bool BooksAllStatus()
    {
        return listBooks.All(x => x.Status != string.Empty);
    }

    public IEnumerable<Book> BooksIn2005()
    {
        if (listBooks.Any(x => x.PublishedDate.Year == 2005))
        {
            return listBooks.Where(x => x.PublishedDate.Year == 2005);
        }
        else
        {
            return default;
        }
    }

    public IEnumerable<Book> BooksPython()
    {
        return listBooks.Where(x => x.Categories.Contains("Python"));
    }

    public IEnumerable<Book> BooksJavaOrder()
    {
        return listBooks.Where(x => x.Categories.Contains("Java")).OrderBy(x => x.Title);
    }

    public IEnumerable<Book> Books450PagesOrderDescending()
    {
        return listBooks.Where(x => x.PageCount > 450).OrderByDescending(x => x.PageCount);
    }

    public IEnumerable<Book> BooksJava3Recent()
    {
        try
        {
            return listBooks.Where(x => x.Categories.Contains("Java")).OrderByDescending(x => x.PublishedDate).Take(3);
        }
        catch
        {
            return listBooks.Where(x => x.Categories.Contains("Java")).OrderBy(x => x.PublishedDate).TakeLast(3);
        }
    }

    public IEnumerable<Book> Books400PagesSkipTake3And4()
    {
        return listBooks.Where(x => x.PageCount > 400).OrderBy(x => x.PageCount).Take(4).Skip(2);
    }

    public IEnumerable<Book> BooksSelect3()
    {
        return listBooks.Take(3).Select(x => new Book { Title = x.Title, PageCount = x.PageCount });
    }

    public int Books200A500Count()
    {
        return listBooks.Where(x => x.PageCount > 200 && x.PageCount < 500).Count();
    }

    public IEnumerable<Book> BooksMinDate()
    {
        DateTime publishedDate = listBooks.Min(x => x.PublishedDate);
        return listBooks.Where(x => x.PublishedDate == publishedDate);
    }

    public IEnumerable<Book> BooksMaxDate()
    {
        DateTime publishedDate = listBooks.Max(x => x.PublishedDate);
        return listBooks.Where(x => x.PublishedDate == publishedDate);
    }

    public Book BookMinByPagesNo0()
    {
        return listBooks.Where(x => x.PageCount > 0).MinBy(x => x.PageCount);
    }

    public Book BookMaxByDate()
    {
        return listBooks.MaxBy(x => x.PublishedDate);
    }

    public int BooksSumPages()
    {
        return listBooks.Where(x => x.PageCount > 0 && x.PageCount <= 500).Sum(x => x.PageCount);
    }

    public string BooksDateAfter2015()
    {
        return listBooks.Where(x => x.PublishedDate.Year > 2015).Aggregate(string.Empty, (bookTitle, next) =>
        {
            if (bookTitle != string.Empty)
            {
                bookTitle += "\n" + next.Title;
            }
            else
            {
                bookTitle += next.Title;
            }   
            return bookTitle;
        });
    }

    public double BooksTitleAverage()
    {
        return listBooks.Average(x => x.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> BooksGroupByYear()
    {
        return listBooks.Where(x => x.PublishedDate.Year > 2000).GroupBy(x => x.PublishedDate.Year);
    }

    public ILookup<char, Book> BooksLookUpFirstChar()
    {
        return listBooks.ToLookup(x => x.Title[0]);
    }

    public IEnumerable<Book> Books500And2005()
    {
        return listBooks.Where(x => x.PageCount > 500).Join(listBooks.Where(x => x.PublishedDate.Year > 2005), book1 => book1.Title, book2 => book2.Title, (book1, book2) => book1);
    }
}