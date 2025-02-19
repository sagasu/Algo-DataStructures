using System.Collections.Generic;

namespace AlgoTest.LeetCode.Letter_Tile_Possibilities;

public class Letter_Tile_Possibilities
{
    public int NumTilePossibilities(string tiles) {
        var len = tiles.Length;
        var seq = new HashSet<string>();

        for (int i = 0; i < len; i++) {
            var c = tiles[i];
            var temp = new HashSet<string>(seq);
            temp.Add(c + "");

            if (i != 0) {
                foreach (string s in seq) {
                    var subLen = s.Length;

                    for (int j = 0; j <= subLen; j++)
                        temp.Add(s.Insert(j, c + ""));
                }
            }

            seq.UnionWith(temp);
        }

        return seq.Count;
    }
}