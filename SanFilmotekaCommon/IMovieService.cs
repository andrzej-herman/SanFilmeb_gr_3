using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanFilmotekaCommon
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMoviesByCategory(string category);
        IEnumerable<Movie> GetMoviesByTitle(string title);
        IEnumerable<Movie> GetMoviesByActor(string actor);
        IEnumerable<Movie> GetRandomMovies();
        IEnumerable<string> GetCategories();
    }
}
