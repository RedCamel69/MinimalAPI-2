using Microsoft.EntityFrameworkCore;
using MinimalAPI_2.Models;


namespace MinimalAPI_2.Data
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDbContext _context;

        public MovieRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            await _context.AddAsync(movie);
        }

        public void UpdateMovie(Movie movie, int id)
        {
            var movieModel = _context.Movies.FirstOrDefaultAsync(t => t.Id == id).Result;

            if (movieModel == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            movieModel.Title = movie.Title;
            movieModel.Synopsis = movie.Synopsis;
            movieModel.Year = movie.Year;

            _context.Movies.Update(movieModel);
        }

        public void DeleteMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            _context.Movies.Remove(movie);
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();          
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
       
    }
}
