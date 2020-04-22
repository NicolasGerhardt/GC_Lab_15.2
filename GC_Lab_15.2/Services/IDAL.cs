using GC_Lab_15._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_Lab_15._2.Services
{
    public interface IDAL
    {
        //int CreateMovie(Movie prod);
        //int DeleteMovieById(int id);
        //Movie GetMovieById(int id);
        string[] GetMovieCategories();
        public IEnumerable<Movie> GetMoviesAll();
        public IEnumerable<Movie> GetMoviesByCategory(string category);
    }
}
