using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                //string[] recentRecipes = LoadRecentRecipes(item.Key);
                //string[] recipesToChooseFrom = ExcludeRecentRecipesFromList(item.Key);
                //string[] selectedRecipes = GetRandomRecipes();
            }

            return new string[] { chosenRecipes, requiredIngredients };
        }
    }
}
