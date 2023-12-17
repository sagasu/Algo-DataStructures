using System.Collections.Generic;

namespace AlgoTest.LeetCode.Design_a_Food_Rating_System;

public class FoodRatings{

    private readonly Dictionary<string, int> dict;
    private readonly Dictionary<string, string> set;
    private readonly Dictionary<string, PriorityQueue<string[], string[]>> map;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings) {
        dict = new Dictionary<string, int>();
        set = new Dictionary<string, string>();
        map = new Dictionary<string, PriorityQueue<string[], string[]>>();
        var n = foods.Length;
        for (int i = 0; i < n; i++)
        {
            dict.Add(foods[i], ratings[i]);
            set.Add(foods[i], cuisines[i]);
            if (!map.ContainsKey(cuisines[i]))
                map.Add(cuisines[i], new PriorityQueue<string[], string[]>(Comparer<string[]>.Create((x, y) =>
                {
                    var rate1 = int.Parse(x[1]);
                    var rate2 = int.Parse(y[1]);
                    if (rate1 > rate2) return -1;
                    return rate1 < rate2 ? 1 : x[0].CompareTo(y[0]);
                })));
            
            map[cuisines[i]].Enqueue(new string[] { foods[i], ratings[i].ToString() }, new string[] { foods[i], ratings[i].ToString() });
        }
    }
    
    public void ChangeRating(string food, int newRating) {
        dict[food] = newRating;
        var cuisine = set[food];
        map[cuisine].Enqueue(new string[] { food, newRating.ToString() }, new string[] { food, newRating.ToString() });
    }
    
    public string HighestRated(string cuisine) {
        var pq = map[cuisine];
        while (pq.Count > 0)
        {
            var top = pq.Peek();
            var rate = int.Parse(top[1]);
            if (dict[top[0]] == rate) return top[0];
            
            pq.Dequeue();
        }
        return "";
    }
}