using GH.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GH.WebUI.Repositories
{
    public class GenreRepository
    {
        private ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres() => _context.Genres.ToList();
    }
}