namespace AlgoTest.LeetCode.Findawinnerontictactoegame;

internal class Findawinnerontictactoegame
{
    public string Tictactoe(int[][] moves)
    {
        char[,] board = new char[3, 3];
        string winner = "Pending";

        //Evaluate the moves
        for (int i = 0; i < moves.Length; i++)
        {
            char mark = i % 2 == 0 ? 'X' : 'O';
            board[moves[i][0], moves[i][1]] = mark;
        }

        // Print board
        // for(int i = 0; i < board.GetLength(0); i++) {
        //     for(int j = 0; j < board.GetLength(1); j++) {
        //         char tmp = board[i,j] == '\0' ? '-' : board[i,j];
        //         Console.Write(tmp + " ");
        //     }
        //     Console.WriteLine("");
        // }

        //Check Diagonal
        if (board[0, 0] != '\0' && (board[0, 0].Equals(board[1, 1]) && board[1, 1].Equals(board[2, 2])) ||
            (board[0, 2].Equals(board[1, 1]) && board[1, 1].Equals(board[2, 0])))
        {
            winner = GetWinner(board[1, 1]);
        }

        //Evaluate the board
        for (int i = 0; i < 3; i++)
        {
            //Check across
            if (board[i, 0] != '\0' && board[i, 0].Equals(board[i, 1]) && board[i, 1].Equals(board[i, 2]))
            {
                winner = GetWinner(board[i, 0]);
            }

            //Check down
            if (board[0, i] != '\0' && board[0, i].Equals(board[1, i]) && board[1, i].Equals(board[2, i]))
            {
                winner = GetWinner(board[0, i]);
            }
        }

        return winner.Equals("Pending") && moves.Length == 9 ? "Draw" : winner;
    }

    private string GetWinner(char val)
    {
        string winner = string.Empty;

        switch (val)
        {
            case 'X': winner = "A"; break;
            case 'O': winner = "B"; break;
            default:
                winner = "Pending";
                break;
        }

        return winner;
    }
}