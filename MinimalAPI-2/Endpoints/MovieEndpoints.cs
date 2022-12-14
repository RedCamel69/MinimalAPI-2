using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalAPI_2.Data;
using MinimalAPI_2.DTOs;
using MinimalAPI_2.Models;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MinimalAPI_2.Endpoints
{
    public static class MovieEndpoints
    {
        public static void MapMovieEndpoints(this WebApplication app)
        {
            app.MapGet("api/filmnoir", async (IMovieRepo repo, IMapper mapper) =>
            {               
                var items = await repo.GetAllMovies();
                return Results.Ok(mapper.Map<IEnumerable<MovieReadDTO>>(items));
            })
                .Produces<IEnumerable<MovieReadDTO>>()
                .RequireAuthorization();
            

            app.MapPost("api/filmnoir", async (IMovieRepo repo, IValidator<Movie> validator , MovieCreateDTO movieCreateDTO, IMapper mapper) =>
            {                
                var movieModel = mapper.Map<Movie>(movieCreateDTO);

                var validationResult = validator.Validate(movieModel);
                if(!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(x => new {errors = x.ErrorMessage });
                    return Results.BadRequest(errors);
                }


                await repo.CreateMovie(movieModel);
                await repo.SaveChanges();
            
                return Results.Created($"api/filmnoir/{movieModel.Id}", 
                        mapper.Map<MovieReadDTO>(movieModel));

            }).Produces<MovieReadDTO>(); ;
               

            app.MapPut("api/filmnoir/{id}", async (IMovieRepo repo, int id, IMapper mapper, MovieUpdateDTO movieUpdateDTO) => {

                var movieModel = await repo.GetMovieById(id);

                if (movieModel == null)
                {
                    return Results.NotFound();
                }

                mapper.Map(movieUpdateDTO, movieModel);

                await repo.SaveChanges();

                return Results.NoContent();

            });

            app.MapDelete("api/filmnoir/{id}", async (IMovieRepo repo, int id, IMapper mapper) => {

                var movieModel = await repo.GetMovieById(id);

                if (movieModel == null)
                {
                    return Results.NotFound();
                }

                repo.DeleteMovie(movieModel);
                await repo.SaveChanges();

                return Results.NoContent();

            });

        }
    }
}
