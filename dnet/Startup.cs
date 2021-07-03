using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace dnet
{
  public class Startup
  {

    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    => this.Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(
          options => options.UseSqlite(
              Configuration.GetConnectionString("TestConnection")));

      services.AddScoped<IAuthorRepository, AuthorRepository>();

      // Add the GraphQL schema to the service configuration
      services
          .AddGraphQLServer()
          .AddDocumentFromString(@"
                type Query {
                  book: Book
                  author: Author
                }

                type Book {
                  title: String
                  author: Author
                }

                type Author {
                    name: String
                }
            ")
            .BindComplexType<Query>()
            .BindComplexType<Book>()
            .BindComplexType<Author>();
      // .AddQueryType<Query>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
