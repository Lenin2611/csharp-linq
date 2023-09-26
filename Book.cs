namespace practicaLinQ.Entities;

public class Book
{
    private string title;
    private int pageCount;
    private DateTime publishedDate;
    private string status;
    private string[] authors;
    private string[] categories;

    public string Title { get => title; set => title = value; }
    public int PageCount { get => pageCount; set => pageCount = value; }
    public DateTime PublishedDate { get => publishedDate; set => publishedDate = value; }
    public string Status { get => status; set => status = value; }
    public string[] Authors { get => authors; set => authors = value; }
    public string[] Categories { get => categories; set => categories = value; }
}