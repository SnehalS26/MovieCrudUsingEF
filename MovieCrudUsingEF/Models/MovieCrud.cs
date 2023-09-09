namespace MovieCrudUsingEF.Models
{
    public class MovieCrud
    {
        ApplicationDbContext context;
        public MovieCrud(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            return context.Movies.Where(x => x.IsActive == 1).ToList();
        }
        public Movie GetMovieById(int id)
        {
            var movie = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            return movie;
        }
        public int AddMovie(Movie movie)
        {
            movie.IsActive = 1;
            int result = 0;
            context.Movies.Add(movie);
            result = context.SaveChanges();
            return result;
        }
        public int UpdateMovie(Movie movie)
        {
            int result = 0;
            var m = context.Movies.Where(x => x.Id == movie.Id).FirstOrDefault();
            if (m != null)
            {
                m.Id = movie.Id;
                m.Name = movie.Name;
                m.Genere = movie.Genere;
                m.Released_Date = movie.Released_Date;
                m.Starcast = movie.Starcast;
                m.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;
        }
        public int DeleteMovie(int id)
        {
            int result = 0;
            var m = context.Movies.Where(x => x.Id == id).FirstOrDefault();
            if (m != null)
            {
               m.IsActive = 0;
                result = context.SaveChanges();
            }
            return result;
        }
    }
}
