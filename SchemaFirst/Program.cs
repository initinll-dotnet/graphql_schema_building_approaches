using SchemaFirst.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddDocumentFromFile("./Schema.graphql")
    .BindRuntimeType<Query>()
    .AddResolver<BookExtension>("Book")
    .InitializeOnStartup();

var app = builder.Build();

app.MapGraphQL();

app.Run();