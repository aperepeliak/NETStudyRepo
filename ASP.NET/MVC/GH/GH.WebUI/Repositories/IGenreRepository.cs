﻿using System.Collections.Generic;
using GH.WebUI.Models;

namespace GH.WebUI.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}