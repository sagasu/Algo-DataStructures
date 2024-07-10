namespace AlgoTest.LeetCode.Crawler_Log_Folder;

public class Crawler_Log_Folder
{
    public int MinOperations(string[] logs) 
    {
        var level = 0;       
        foreach(var l in logs)
        {
            if (l == "../") {
                if(level > 0) level--;
            } else if(l != "./")
                level++;
        }
        
        return level;
    }
}