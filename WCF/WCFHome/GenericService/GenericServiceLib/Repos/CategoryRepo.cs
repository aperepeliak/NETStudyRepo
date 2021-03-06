﻿using GenericServiceLib.Models;
using System;

namespace GenericServiceLib.Repos
{
    [Serializable]
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo()
        {
            Table = Context.Categories;
        }
    }
}
