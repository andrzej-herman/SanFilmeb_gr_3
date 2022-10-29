using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataJsonCreator
{
    internal class FileWritter
    {
        private readonly string path;
        private readonly List<Movie> movies;

        public FileWritter(string path, List<Movie> movies)
        {
            this.path = path;
            this.movies = movies;
        }

        public void SaveFile()
        {
            Console.WriteLine();
            Console.WriteLine(" Trwa zapis pliku ...");
            var json = JsonConvert.SerializeObject(this.movies);
            File.WriteAllText(path, json);
            Console.WriteLine($" Plik zapisano w {path}");
        }
    }
}
