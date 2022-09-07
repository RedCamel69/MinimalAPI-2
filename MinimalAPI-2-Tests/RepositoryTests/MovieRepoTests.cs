using MinimalAPI_2_Tests.RepositoryTests;
using System.Linq;

namespace MinimalAPI_2_Tests
{
    public class MovieRepoTests
    {
        [Fact]
        public void MovieRepo_GetAllMovies_Returns_All_Movies()
        {

            // ARRANGE
            var mock = MockIMovieRepo.GetMock();

            // ACT
            var movies = mock.Object.GetAllMovies().Result;

            // ASSERT
            Assert.True(movies.Count() == 2);

        }

        [Fact]
        public void MovieRepo_GetMovieByID_Returns_Expected_Movie()
        {

            // ARRANGE
            var mock = MockIMovieRepo.GetMock();

            // ACT
            var movie = mock.Object.GetMovieById(1).Result;

            // ASSERT
            Assert.True(movie.Id==1);

        }
    }
}