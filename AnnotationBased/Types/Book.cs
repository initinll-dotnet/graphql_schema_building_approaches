namespace AnnotationBased.Types;

public record Book(string Title, Author Author);

[ExtendObjectType<Book>]
public static class BookExtension
{
    public static string DisplayName([Parent] Book book)
        => $"{book.Author.Name}: {book.Title}";
}