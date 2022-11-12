using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanFilmotekaCommon
{
    public class MovieService : IMovieService
    {
        public MovieService()
        {
            GetMoviesFromJson();
            Random = new Random();
        }

        private IEnumerable<Movie> Movies { get; set; }
        private Random Random { get; set; }

        private void GetMoviesFromJson()
        {
            var json = File.ReadAllText("wwwroot\\data\\baza_filmow.json");
            Movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(json);
        }

        public IEnumerable<string> GetCategories()
        {
            return Movies.Select(m => m.Genre).Distinct().OrderBy(c => c);
        }

        public IEnumerable<Movie> GetMoviesByActor(string actor)
        {
            return Movies.Where(m => m.Cast.Contains(actor));
        }

        public IEnumerable<Movie> GetMoviesByCategory(string category)
        {
            return Movies.Where(m => m.Genre == category);
        }

        public IEnumerable<Movie> GetMoviesByTitle(string title)
        {
            return Movies.Where(m => m.Title.ToLower().Contains(title.ToLower()));
        }

        public IEnumerable<Movie> GetRandomMovies()
        {
            return Movies.OrderBy(m => Random.Next()).Take(6);
        }
    }
}
