namespace SchemaFirst.Types;

public record Book(string Title, Author Author);


public class BookExtension
{
    public string DisplayName([Parent] Book book)
        => $"{book.Author.Name}: {book.Title}";
}
