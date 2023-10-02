namespace AlgoTest.LeetCode.Remove_Colored_Pieces_if_Both_Neighbors_are_the_Same_Color;

public class Remove_Colored_Pieces_if_Both_Neighbors_are_the_Same_Color
{
    public bool WinnerOfGame(string colors) {
        var alice = 0;
        var bob = 0;
        
        for(var i = 1; i < colors.Length - 1; i++)
            if(colors[i] == colors[i - 1] && colors[i + 1] == colors[i]) {
                if(colors[i] == 'A') alice++;
                else bob++;
            }
        
        return bob < alice;
    }
}