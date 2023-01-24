public class Solution {
     public int SnakesAndLadders(int[][] board) {
        var bLength = board.Length;
        Array.Reverse(board);
        Queue<(int square,int moves)> queue = new();
        queue.Enqueue((1,0));
        HashSet<int> visited = new();

        while(queue.Any())
        {
            
            var currItem = queue.Dequeue();
            for (var i = 1; i < 7; i++)
            {
                var nextSquare = currItem.square + i;
                var newCoord = getInttoPos(nextSquare, bLength);
                if (board[newCoord.row][newCoord.col] != -1)
                {
                    nextSquare = board[newCoord.row][newCoord.col];
                }

                if (nextSquare == bLength * bLength)
                {
                    return currItem.moves + 1;
                }

                if (!visited.Contains(nextSquare))
                {
                    visited.Add(nextSquare);
                    queue.Enqueue((nextSquare, currItem.moves + 1));
                }
            }
        }
        return -1;
    }
    
    private (int row,int col) getInttoPos(int square, int length)
    {
        int row = (square-1)/length;
        int col = (square-1) % length;
        if(row %2!=0)
        {
            col = length - 1-col;
        }
        return (row,col);
    }

}