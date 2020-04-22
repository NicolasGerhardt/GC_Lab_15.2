using Dapper;
using GC_Lab_15._2.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GC_Lab_15._2.Services
{
    public class DALSqlServer : IDAL
    {

        private readonly string connectionString;

        public DALSqlServer(IConfiguration config)
        {
            connectionString = config.GetConnectionString("MovieAPIDB");
        }

        public string[] GetMovieCategories()
        {

            SqlConnection connection = null;
            string queryString = "SELECT DISTINCT Category FROM Movies";
            string[] categories = null;

            try
            {
                connection = new SqlConnection(connectionString);
                categories = connection.Query<string>(queryString).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    
                    connection.Close(); //explicitly closing the connection
                }
            }

            

            return categories;

        }

        public IEnumerable<Movie> GetMoviesAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies";
            IEnumerable<Movie> movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                movies = connection.Query<Movie>(queryString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return movies;
        }

        public IEnumerable<Movie> GetMoviesByCategory(string category)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies where Category like @Category";
            IEnumerable<Movie> Products = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Products = connection.Query<Movie>(queryString, new { Category = "%" + category + "%" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Products;
        }
    }
}
