﻿using GenericServiceLib.Models;
using System;

namespace GenericServiceLib.Repos
{
    [Serializable]
    public class ManufacturerRepo : GenericRepo<Manufacturer>, IManufacturerRepo
    {
        public ManufacturerRepo()
        {
            Table = Context.Manufacturers;
        }
    }
}
