using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_All_Possible_Recipes_from_Given_Supplies;

public class Find_All_Possible_Recipes_from_Given_Supplies
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        var availableSupplies = new HashSet<string>(supplies);
        var recipeToIngredients = new Dictionary<string, List<string>>();
        var visited = new Dictionary<string, int>();
        var result = new List<string>();

        for (int i = 0; i < recipes.Length; i++) {
            recipeToIngredients[recipes[i]] = new List<string>(ingredients[i]);
        }

        bool CanMake(string recipe) {
            if (visited.ContainsKey(recipe)) {
                return visited[recipe] == 1;
            }

            if (availableSupplies.Contains(recipe)) {
                return true;
            }

            if (!recipeToIngredients.ContainsKey(recipe)) {
                return false;
            }

            visited[recipe] = 0;

            foreach (string ingredient in recipeToIngredients[recipe]) {
                if (!CanMake(ingredient)) {
                    visited[recipe] = -1;
                    return false;
                }
            }

            visited[recipe] = 1;
            result.Add(recipe);
            return true;
        }

        foreach (string recipe in recipes) {
            CanMake(recipe);
        }

        return result;
    }
}