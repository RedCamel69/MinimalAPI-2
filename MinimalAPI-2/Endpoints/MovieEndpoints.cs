using Microsoft.EntityFrameworkCore;
using MinimalAPI_2.Data;
using MinimalAPI_2.Models;

namespace MinimalAPI_2.Endpoints
{
    public static class MovieEndpoints
    {
        public static void MapMovieEndpoints(this WebApplication app)
        {
            app.MapGet("api/filmnoir", async (AppDbContext context) =>
            {
                var items = await context.Movies.ToListAsync();

                return Results.Ok(items);
            });

            app.MapPost("api/filmnoir", async (IMovieRepo repo, Movie movie) =>
            {
                await repo.CreateMovie(movie);
                await repo.SaveChanges();


                return Results.Created($"api/filmnoir/{movie.Id}", movie);

            });

            app.MapPut("api/filmnoir/{id}", async (AppDbContext context, int id, Movie movie) => {

                var movieModel = await context.Movies.FirstOrDefaultAsync(t => t.Id == id);

                if (movieModel == null)
                {
                    return Results.NotFound();
                }

                movieModel.Title= movie.Title;
                movieModel.Synopsis = movie.Synopsis;
                movieModel.Year= movie.Year;

                await context.SaveChangesAsync();

                return Results.NoContent();

            });

            app.MapDelete("api/filmnoir/{id}", async (AppDbContext context, int id) => {

                var movieModel = await context.Movies.FirstOrDefaultAsync(t => t.Id == id);

                if (movieModel == null)
                {
                    return Results.NotFound();
                }

                context.Movies.Remove(movieModel);

                await context.SaveChangesAsync();

                return Results.NoContent();

            });

        }
    }
}
