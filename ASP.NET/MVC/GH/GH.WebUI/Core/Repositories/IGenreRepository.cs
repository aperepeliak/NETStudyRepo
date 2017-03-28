using System.Collections.Generic;
using GH.WebUI.Core.Models;

namespace GH.WebUI.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}