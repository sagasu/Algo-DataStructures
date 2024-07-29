namespace AlgoTest.LeetCode.Count_Number_of_Teams;

public class Count_Number_of_Teams
{
    public int NumTeams(int[] rating) 
    {
        int n = rating.Length, count = 0;
        for(int i = 1; i < n - 1; i++)
        {
            int curr = rating[i], leftSmaller = 0, leftBigger = 0, rightSmaller = 0, rightBigger = 0;
            for(int l = 0; l < i; l++)
            {
                if(rating[l] < curr) leftSmaller++;
                if(rating[l] > curr) leftBigger++;
            }
            
            for(int r = i + 1; r < n; r++)
            {
                if(rating[r] < curr) rightSmaller++;
                if(rating[r] > curr) rightBigger++;
            }
            
            count += (leftSmaller * rightBigger) + (leftBigger * rightSmaller);
        }
        return count;
    }
}