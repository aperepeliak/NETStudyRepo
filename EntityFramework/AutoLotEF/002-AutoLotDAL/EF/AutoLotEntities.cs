namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using AutoLotDAL.Models;

    public class AutoLotEntities : DbContext
    {
        public AutoLotEntities()
            : base("name=AutoLotConnection") { }


    }
}