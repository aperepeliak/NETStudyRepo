using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MainMenu.Generator
{
    public static class GeneratorEngine
    {
        public static string[] GetMenu(RecipesModel model, GeneratorParams genParams)
        {
            string chosenRecipes = string.Empty;
            string requiredIngredients = string.Empty;

            var season = genParams.Season;
            foreach (var item in genParams.CategoryQuantity)
            {
                string categoryRecipes = string.Empty;
                string categoryRecipesIngredients = string.Empty;

                GenerateForGivenCategory(item.Key, item.Value, season,
                    out categoryRecipes, out categoryRecipesIngredients);
            }

            return new string[] { chosenRecipes, requiredIngredients };
        }

        private static void GenerateForGivenCategory(string key, int value, string seasons, 
            out string categoryRecipes, out string categoryRecipesIngredients)
        {

        }
    }
}
