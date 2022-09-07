using MinimalAPI_2.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MinimalAPI_2.Data
{
    public interface IMovieRepo
    {
        Task SaveChanges();
        Task<Movie?> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task CreateMovie(Movie cmd);

        void UpdateMovie(Movie cmd, int id);

        void DeleteMovie(Movie cmd);
    }
}
