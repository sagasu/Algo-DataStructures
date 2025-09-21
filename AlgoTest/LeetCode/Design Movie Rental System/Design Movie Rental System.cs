using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Design_Movie_Rental_System;

public class MovieRentingSystem
{
    private static Comparer<Entry> unrentedMoviesComparer = Comparer<Entry>.Create((a, b) =>
    {
        if (a.Price != b.Price)
        {
            return a.Price.CompareTo(b.Price);
        }
        return a.Shop.CompareTo(b.Shop);
    });

    private static Comparer<Entry> rentedMoviesComparer = Comparer<Entry>.Create((a, b) =>
    {
        if (a.Price != b.Price)
        {
            return a.Price.CompareTo(b.Price);
        }
        if (a.Shop != b.Shop)
        {
            return a.Shop.CompareTo(b.Shop);
        }
        return a.Movie.CompareTo(b.Movie);
    });

    private readonly Dictionary<(int Shop, int Movie), Entry> entriesByShopAndMovie = new();

    private readonly Dictionary<int, SortedSet<Entry>> unrentedMovies = new();

    private readonly SortedSet<Entry> rentedMovies = new SortedSet<Entry>(rentedMoviesComparer);

    public MovieRentingSystem(int n, int[][] entries)
    {
        foreach (var e in entries)
        {
            var shop = e[0];
            var movie = e[1];

            var entry = new Entry(shop, movie, e[2]);

            if (!unrentedMovies.ContainsKey(movie))
            {
                unrentedMovies[movie] = new SortedSet<Entry>(unrentedMoviesComparer) { entry };
            }
            else
            {
                unrentedMovies[movie].Add(entry);
            }

            entriesByShopAndMovie[(shop, movie)] = entry;
        }
    }

    public IList<int> Search(int movie)
    {
        if (unrentedMovies.TryGetValue(movie, out var list))
        {
            return list.Take(5).Select(e => e.Shop).ToList();
        }
        return [];
    }

    public void Rent(int shop, int movie)
    {
        var entry = entriesByShopAndMovie[(shop, movie)];
        unrentedMovies[movie].Remove(entry);
        rentedMovies.Add(entry);
    }

    public void Drop(int shop, int movie)
    {
        var entry = entriesByShopAndMovie[(shop, movie)];
        rentedMovies.Remove(entry);
        unrentedMovies[movie].Add(entry);
    }

    public IList<IList<int>> Report()
    {
        return rentedMovies.Take(5).Select(e => new List<int> { e.Shop, e.Movie }).ToList<IList<int>>();
    }

    public record Entry(int Shop, int Movie, int Price);

}