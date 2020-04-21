using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC_Lab_15._2.Models;
using GC_Lab_15._2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC_Lab_15._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IDAL dal;

        public MovieController(IDAL dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        public IEnumerable<Movie> Get(string? category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return dal.GetMoviesAll();
            }

            return dal.GetMoviesByCategory(category);

        }

        [HttpGet("random")]
        public Movie GetRandom(string? category)
        {
            Random r = new Random();
            Movie[] movies = null;

            if (string.IsNullOrEmpty(category))
            {
                movies = dal.GetMoviesAll().ToArray();
            }
            else
            {
                movies = dal.GetMoviesByCategory(category).ToArray();
            }



            Movie randomMovie = movies[r.Next(movies.Length)];
            return randomMovie;

        }



    }
}