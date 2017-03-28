using GH.WebUI.Core.Models;
using GH.WebUI.Core.Repositories;
using GH.WebUI.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace GH.WebUI.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres() => _context.Genres.ToList();
    }
}