using MG.Entities;
using MG.MainMenu;
using MG.MainMenu.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new RecipesModel();

            //string[] chosenRecipesList = { "уха", "толченка" };

            //var requiredIngrdedients = model.Recipes
            //     .Where(r => chosenRecipesList.Contains(r.Name))
            //     .SelectMany(r => r.Ingredients)
            //     .ToList();

            //var res = requiredIngrdedients
            //    .GroupBy(ii => ii.Ingredient.Name)
            //    .Select(g =>
            //    {
            //        return new IngredientInfo
            //        {
            //            Ingredient = new Ingredient { Name = g.Key },
            //            Amount = g.Sum(a => a.Amount)
            //        };
            //    })
            //    .ToList();

            //foreach (var i in res)
            //{
            //    Console.WriteLine($"Ingredient: {i.Ingredient.Name} Amount: {i.Amount} {i.Ingredient.Units}");
            //    //Console.WriteLine(i.Key);
            //}

            var res = model.GetRequiredIndredients(new List<string>
            {
                "уха", "толченка", "жаркое", "пицца"
            });

            foreach (var item in res)
            {
                Console.WriteLine($"Ingredient: {item.Ingredient.Name} : {item.Amount} {item.Ingredient.Units}");
            }

            Console.ReadLine();
        }
    }
}
