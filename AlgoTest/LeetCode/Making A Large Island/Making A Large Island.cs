using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Making_A_Large_Island;

public class Making_A_Large_Island
{
    public int LargestIsland(int[][] grid)
  {
      int n = grid.Length;
      int index = 2;
      Dictionary<int, int> islandSize = new Dictionary<int, int>();
      bool hasZero = false;
      int maxIsland = 0;

      for (int i = 0; i < n; i++)
      {
          for (int j = 0; j < n; j++)
          {
              if (grid[i][j] == 1)
              {
                  int size = DFS(grid, i, j, index);
                  islandSize[index] = size;
                  maxIsland = Math.Max(maxIsland, size);
                  index++;
              }
              else
              {
                  hasZero = true;
              }
          }
      }

      if (!hasZero) return maxIsland;

      for (int i = 0; i < n; i++)
      {
          for (int j = 0; j < n; j++)
          {
              if (grid[i][j] == 0)
              {
                  HashSet<int> seenIslands = new HashSet<int>();
                  int newSize = 1;
                  int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

                  foreach (var dir in directions)
                  {
                      int ni = i + dir[0], nj = j + dir[1];

                      if (ni >= 0 && ni < n && nj >= 0 && nj < n && grid[ni][nj] > 1)
                      {
                          int islandIndex = grid[ni][nj];

                          if (seenIslands.Add(islandIndex))
                          {
                              newSize += islandSize[islandIndex];
                          }
                      }
                  }

                  maxIsland = Math.Max(maxIsland, newSize);
              }
          }
      }

      return maxIsland;
  }
  private int DFS(int[][] grid, int i, int j, int index)
  {
      int n = grid.Length;
      if (i < 0 || i >= n || j < 0 || j >= n || grid[i][j] != 1) return 0;

      grid[i][j] = index;
      int size = 1;
      int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
      foreach (var dir in directions)
      {
          size += DFS(grid, i + dir[0], j + dir[1], index);
      }

      return size;
  }
}