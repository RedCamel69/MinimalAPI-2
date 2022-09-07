using Microsoft.EntityFrameworkCore;
using MinimalAPI_2.Data;
using MinimalAPI_2.Models;

namespace MinimalAPI_2.Endpoints
{
    public static class MovieEndpoints
    {
        public static void MapMovieEndpoints(this WebApplication app)
        {
            app.MapGet("api/filmnoir", async (IMovieRepo repo) =>
            {
                var items = await repo.GetAllMovies();

                return Results.Ok(items);
            });

            app.MapPost("api/filmnoir", async (IMovieRepo repo, Movie movie) =>
            {
                await repo.CreateMovie(movie);
                await repo.SaveChanges();


                return Results.Created($"api/filmnoir/{movie.Id}", movie);

            });

            app.MapPut("api/filmnoir/{id}", async (IMovieRepo repo, int id, Movie movie) => {

                repo.UpdateMovie(movie, id);

                await repo.SaveChanges();

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
