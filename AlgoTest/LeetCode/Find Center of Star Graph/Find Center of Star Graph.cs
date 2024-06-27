namespace AlgoTest.LeetCode.Find_Center_of_Star_Graph;

public class Find_Center_of_Star_Graph
{
    public int FindCenter(int[][] edges)
    {
        if (edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1])
            return edges[0][0];

        return edges[0][1];
    }
}