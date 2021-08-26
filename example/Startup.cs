using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace example
{
  public class Startup
  {
    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => this.Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(
          options => options.UseSqlite(
              Configuration.GetConnectionString("TestConnection")),
              ServiceLifetime.Singleton);

      services.AddScoped<IAuthorRepository, AuthorRepository>();
      services.AddScoped<IBookRepository, BookRepository>();

      // Add the GraphQL schema to the service configuration
      services
          .AddGraphQLServer()
          .AddDocumentFromString(@"
                #type Mutation {
                #  addAuthor(input: Author): Author
                #}

                type Query {
                  book: Book
                  author: Author
                  authors: [Author]
                  # getAuthorById(id: ID!): Author
                }

                type Book {
                  title: String
                  # author: Author
                }

                type Author {
                  id: String!
                  name: String!
                }
            ")
            .BindComplexType<Query>()
            // .AddQueryType<Query>()
            .BindComplexType<Book>()
            .BindComplexType<Author>()
            // .BindComplexType<Mutation>()
            .AddMutationType<Mutation>()
            // Tell me the errors!
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
    {
      // Add the graphql end point responders
      app
          .UseRouting()
          .UseEndpoints(endpoints =>
          {
            endpoints.MapGraphQL();
          });
    }
  }
}
