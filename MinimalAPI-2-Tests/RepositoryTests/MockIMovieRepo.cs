using MinimalAPI_2.Data;
using MinimalAPI_2.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MinimalAPI_2_Tests.RepositoryTests
{
    internal class MockIMovieRepo
    {
        public static Mock<IMovieRepo> GetMock()
        {
            var mock = new Mock<IMovieRepo>();

            var movies = new List<Movie>()
        {
            new Movie()
            {
                Id = 1,
                Title = "The Long Goodbye",
                Synopsis= "The Long Goodbye is a 1973 American neo-noir[2][3][4] satirical mystery crime thriller film directed by Robert Altman and based on Raymond Chandler's 1953 novel.",
                 Year=1973
            },
                        new Movie()
            {
                Id = 2,
                Title = "Sunset Boulevard",
                Synopsis= "Sunset Boulevard (styled in the main title on-screen as SUNSET BLVD.) is a 1950 American black comedy film noir directed and co-written by Billy Wilder",
                 Year=1950
            }
        };
          

                mock.Setup<Task<IEnumerable<Movie>>>(m => m.GetAllMovies()).Returns(Task.FromResult<IEnumerable<Movie>>(movies)); ;

                mock.Setup<Task<Movie?>>(m => m.GetMovieById(It.IsAny<int>()))
                    //.Returns(Task.FromResult<Movie?> (new Movie() { Id=1, Synopsis="WWW"}));
                    .Returns(Task.FromResult<Movie?>(movies[0]));
                   // .Returns(Task.FromResult<Movie?>((int id)=>movies.FirstOrDefault(x=>x.Id==id));
          

      

                //mock.Setup(m => m.CreateMovie(It.IsAny<Movie>()))
                //    .Callback(() => { return; });

                //mock.Setup(m => m.DeleteMovie(It.IsAny<Movie>()))
                //   .Callback(() => { return; });
            
           

            return mock;
        }
    }
}