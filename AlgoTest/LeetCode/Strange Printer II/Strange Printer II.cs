using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Strange_Printer_II;

public class Strange_Printer_II
{
    private static bool TryColor(int[][] grid, 
        int color, 
        (int left, int top, int right, int bottom) rect) {
        bool result = true;
        
        for (int r = rect.top; r <= rect.bottom; ++r)
        for (int c = rect.left; c <= rect.right; ++c)
            if (grid[r][c] > 0 && grid[r][c] != color)
                return false;
        
        for (int r = rect.top; r <= rect.bottom; ++r)
        for (int c = rect.left; c <= rect.right; ++c)
            grid[r][c] = 0;
        
        return true;
    }
    
    public bool IsPrintable(int[][] targetGrid) {
        Dictionary<int, (int left, int top, int right, int bottom)> patches = new();

        HashSet<int> colors = new();

        for (int r = 0; r < targetGrid.Length; ++r)
        for (int c = 0; c < targetGrid[r].Length; ++c) {
            int color = targetGrid[r][c];

            colors.Add(color);

            if (patches.TryGetValue(color, out var rect)) {
                patches[color] = (
                    Math.Min(c, rect.left),
                    Math.Min(r, rect.top),
                    Math.Max(c, rect.right),
                    Math.Max(r, rect.bottom)
                );
            }
            else
                patches.Add(color, (c, r, c, r));
        }

        for (bool agenda = true; agenda;) {
            agenda = false;

            foreach (var color in colors.ToList()) {
                if (TryColor(targetGrid, color, patches[color])) {
                    agenda = true;

                    colors.Remove(color);
                }
            }
        }

        return colors.Count <= 0;
    }
}