namespace AlgoTest.LeetCode.Count_Collisions_on_a_Road;

public class Count_Collisions_on_a_Road
{
    public int CountCollisions(string directions)
    {
        int i = 0, j = directions.Length - 1;

        while (i < directions.Length && directions[i] == 'L') i++;
        while (j >= 0 && directions[j] == 'R') j--;

        int count = 0;

        for (int k = i; k <= j; k++)
            if (directions[k] != 'S') count++;

        return count;
    }
}