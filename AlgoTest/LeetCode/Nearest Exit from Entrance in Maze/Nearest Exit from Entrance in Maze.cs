using System.Collections.Generic;

public class Solution16 {
    public int NearestExit(char[][] maze, int[] entrance) {
        int ROWS = maze.Length;
        int COLS = maze[0].Length;
        Queue<(int,int,int)> mQue = new();
        mQue.Enqueue((entrance[0],entrance[1],0));
                
        while(mQue.Count > 0){
            (var r, var c, var s) = mQue.Dequeue();
            if(r < 0 || r >= ROWS || c < 0 || c >= COLS || maze[r][c] == '+'){
                continue;
            }
            if((r != entrance[0] || c != entrance[1]) && (r == 0 || r == ROWS - 1 || c == 0 || c == COLS - 1)){
                return s;
            }
            //Leave visited breadcrumb
            maze[r][c] = '+';

            (int,int)[] nextSteps = new[]{(r + 1, c), (r - 1, c), (r, c + 1), (r, c - 1)};
            foreach((var nextr, var nextc) in nextSteps){
                mQue.Enqueue((nextr, nextc, s + 1));
            }
        }

        return -1;
    }
}