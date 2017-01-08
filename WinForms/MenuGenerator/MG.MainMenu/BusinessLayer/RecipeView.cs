using MG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MainMenu.BusinessLayer
{
    public class RecipeView
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Seasonality { get; set; }


        public static List<RecipeView> GetRecipesInfo(RecipesModel data)
        {
            var query = data.Recipes
                .Select(r => new RecipeView
                {
                    Name = r.Name,
                    Category = r.Category,
                    Seasonality = r.Seasonality
                });

            return query.ToList();
        }
    }
}
