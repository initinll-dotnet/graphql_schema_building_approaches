namespace CodeFirst.Types;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.Title);
        descriptor.Field(t => t.Author);

        descriptor.Field("displayName")
            .Type<NonNullType<StringType>>()
            .Resolve(
                ctx => 
                {
                    var book = ctx.Parent<Book>();
                    return $"{book.Author.Name}: {book.Title}";
                });

        descriptor.Field("displayAuthor")
            .Type<NonNullType<StringType>>()
            .ResolveWith<AuthorResolver>(t => t.DisplayAuthor(default!));
    }

    private class AuthorResolver
    {
        public string DisplayAuthor([Parent] Book book)
            => $"{book.Author.Name}";
    }
}
