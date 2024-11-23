using System.Linq;

namespace AlgoTest.LeetCode.Rotating_the_Box;

public class Rotating_the_Box
{
    public char[][] RotateTheBox(char[][] box) {
        var result = Enumerable
            .Range(0, box[0].Length)
            .Select(_ => new char[box.Length])
            .ToArray();

        for (var r = 0; r < box.Length; ++r) {
            var rr = box.Length - 1 - r;
            
            var at = box[0].Length - 1;

            for (var c = box[0].Length - 1; c >= 0; --c) {
                var letter = box[r][c];

                result[c][rr] = letter;

                if (letter == '*') 
                    at = c - 1;
                else if (letter == '#') {
                    result[c][rr] = '.';
                    result[at--][rr] = '#';
                }
            }
        }

        return result;
    }
}