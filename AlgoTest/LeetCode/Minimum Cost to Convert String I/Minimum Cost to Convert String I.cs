namespace AlgoTest.LeetCode.Minimum_Cost_to_Convert_String_I;

public class Minimum_Cost_to_Convert_String_I
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
        const int charMax = 26;
        const long checker = 10000000;//10^7
        var matrix = new long[charMax, charMax];
        for (var i = 0; i< charMax; i++) {
            for (var j = 0; j < charMax; j++)
                matrix[i, j] = checker;
            
            matrix[i, i] = 0;
        }
        
        for (int i = 0; i < original.Length; i++) {
            var from = original[i] - 'a';
            var to = changed[i] - 'a';
            if (cost[i] < matrix[from, to])
                matrix[from, to] = cost[i];
            
        }

        long temp = 0;
        for (var k = 0; k < charMax; k++) {
            for (var i = 0; i < charMax; i++) {
                for (var j = 0; j < charMax; j++) {
                    temp = matrix[i, k] + matrix[k, j];
                    if (temp < matrix[i, j]) 
                        matrix[i, j] = temp;
                    
                }
            }
        }

        long minimum = 0;
        for (int i = 0; i < target.Length; i++) {
            if (source[i] != target[i]) {
                temp = matrix[source[i] - 'a', target[i] - 'a'];
                if (temp == checker) 
                    return -1;
                
                minimum += temp;
            }
        }
        return minimum;
    }
}