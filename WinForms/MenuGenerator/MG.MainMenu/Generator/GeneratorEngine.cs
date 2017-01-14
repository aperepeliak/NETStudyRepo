using MG.Entities;
using MG.MainMenu.DataLayer;
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
        public static void GetMenu(RecipesModel recipesModel, RecentRecipesModel recentRecipesModel,
            GeneratorParams genParams,
            out List<string> chosenRecipes, out List<string> requiredIngredients)
        {
            chosenRecipes = new List<string>();
            string[] recentRecipes = recentRecipesModel.RecentRecipes.ToArray();

            var seasons = genParams.Seasons;
            foreach (var item in genParams.CategoryQuantity)
            {
                string[] recipesToChooseFrom = GetRecipesToChooseFrom(recentRecipes, recipesModel, item.Key, seasons);

                if (recipesToChooseFrom.Length < item.Value)
                {
                    throw new Exception("Недостаточно рецептов заданной категории");
                }
                else
                {
                    string[] selectedRecipesOfCategory = GetRandomRecipes(item.Value, recipesToChooseFrom);
                    chosenRecipes.AddRange(selectedRecipesOfCategory);
                }
            }

            // recentRecipesModel.SaveDataToXml(chosenRecipesList);

            requiredIngredients = recipesModel.GetRequiredIndredients(chosenRecipes);
        }

        private static string[] GetRandomRecipes(int quantity, string[] recipesToChooseFrom)
        {
            var selected = new List<string>();
            var needed = quantity;
            var available = recipesToChooseFrom.Length;
            var rand = new Random();

            while (selected.Count < quantity)
            {
                double chance = rand.NextDouble();
                if (chance < (double)needed / available)
                {
                    selected.Add(recipesToChooseFrom[available - 1]);
                    needed--;
                }
                available--;
            }

            return selected.ToArray();
        }

        private static string[] GetRecipesToChooseFrom(string[] recentRecipes, RecipesModel recipesModel,
            string category, string[] seasons)
        {
            List<string> recipesOfCategoryAndSeason = recipesModel.GetAllRecipesOfSeasonAndCategory(category, seasons);

            return recipesOfCategoryAndSeason
                .Where(r => !recentRecipes.Contains(r))
                .ToArray();
        }
    }
}
