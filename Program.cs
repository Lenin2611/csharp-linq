using System.Linq;
using practicaLinQ;
using practicaLinQ.Entities;

Console.Clear();
LinqQueries queries = new LinqQueries();
// ImprimirValores(queries.AllCollections());
// ImprimirValores(queries.Books2000());
// ImprimirValores(queries.BooksAndroid());
// ImprimirValores(queries.BooksAndroid2010());
// ImprimirValores(queries.Books250Action());
// Console.WriteLine(queries.BooksAllStatus() ? "Todos los libros contiene un Status" : "Al menos uno de los libros no contiene un Status");
// ImprimirValores(queries.BooksIn2005());
// ImprimirValores(queries.BooksPython());
// ImprimirValores(queries.BooksJavaOrder());
// ImprimirValores(queries.Books450PagesOrderDescending());
// ImprimirValores(queries.BooksJava3Recent());
// ImprimirValores(queries.Books400PagesSkipTake3And4());
// ImprimirValores(queries.BooksSelect3());
// Console.WriteLine(queries.Books200A500Count());
// ImprimirValores(queries.BooksMinDate());
// ImprimirValores(queries.BooksMaxDate());
// ImprimirValoresBook(queries.BookMinByPagesNo0());
// ImprimirValoresBook(queries.BookMaxByDate());
// Console.WriteLine(queries.BooksSumPages());
// Console.WriteLine(queries.BooksDateAfter2015());
// Console.WriteLine(queries.BooksTitleAverage());
// PrintBookGroups();
// PrintBookLookUp();
// ImprimirValores(queries.Books500And2005());

void PrintBookLookUp()
{
    var lookup = queries.BooksLookUpFirstChar();

    foreach (var group in lookup)
    {
        Console.WriteLine($"Carácter Inicial: {group.Key}");
        foreach (var book in group)
        {
            Console.WriteLine($"  Título: {book.Title}");
            // Puedes agregar más detalles del libro aquí si lo deseas.
        }
        Console.WriteLine(); // Separador entre grupos
    }
}

void PrintBookGroups()
{
    var groupedBooks = queries.BooksGroupByYear();

    foreach (var group in groupedBooks)
    {
        Console.WriteLine($"Año de Publicación: {group.Key}");
        foreach (var book in group)
        {
            Console.WriteLine($"  Título: {book.Title}");
            // Puedes agregar más detalles del libro aquí si lo deseas.
        }
        Console.WriteLine(); // Separador entre grupos
    }
}

void ImprimirValores(IEnumerable<Book> books)
{
    if (books != null)
    {
        int registros = 0;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("{0,-70} {1,7} {2,20}", "Titulo", "N. Paginas", "Fecha Publicacion");
        foreach (Book book in books)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            registros += 1;
            Console.WriteLine("{0,-70} {1,7} {2,20}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Libros con esas condiciones no encotrados");
    }
    Console.ForegroundColor = ConsoleColor.Gray;
}

void ImprimirValoresBook(Book book)
{
    if (book != null)
    {
        int registros = 0;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("{0,-70} {1,7} {2,20}", "Titulo", "N. Paginas", "Fecha Publicacion");
        Console.ForegroundColor = ConsoleColor.Yellow;
        registros += 1;
        Console.WriteLine("{0,-70} {1,7} {2,20}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Libros con esas condiciones no encotrados");
    }
    Console.ForegroundColor = ConsoleColor.Gray;
}