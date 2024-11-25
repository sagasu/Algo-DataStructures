using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Sliding_Puzzle;

public class Sliding_Puzzle
{
    Queue<string> queue = new();
    Dictionary<string, int> sp = new();
    const string FINAL_BOARD = "123450";
    int result = -1;
    
    public int SlidingPuzzle(int[][] board) {
        var encodedBoard = EncodeBoard(board);
        if(FINAL_BOARD == encodedBoard) return 0;
        queue.Enqueue(encodedBoard);
        sp[encodedBoard] = 0;
        while(queue.Count > 0) {
            string cur = queue.Dequeue();
            UpdateFringeNeighbors(cur);
            if(-1 != result)
                return result;
        }
        return -1;
    }
    
    public string EncodeBoard(int[][] board) {
        var chars = new char[6] {
            (char)(48 + board[0][0]),
            (char)(48 + board[0][1]),
            (char)(48 + board[0][2]),
            (char)(48 + board[1][0]),
            (char)(48 + board[1][1]),
            (char)(48 + board[1][2]),
        };
        return new String(chars);
    }
    
    public void UpdateFringeNeighbors(string board) {
        int zeroLoc = board.IndexOf('0');
        int left = zeroLoc - 1, 
            right = zeroLoc + 1,
            up = zeroLoc - 3,   
            down = zeroLoc + 3;
        if(left != -1 && left != 2 && 
           EnqueueIfEligible(board, zeroLoc, left))
            return;
        if(right != 3 && right != 6 && 
           EnqueueIfEligible(board, zeroLoc, right))
            return;
        if(up > -1 && EnqueueIfEligible(board, zeroLoc, up))
            return;
        if(down < 6 && EnqueueIfEligible(board, zeroLoc, down))
            return;
    }
    
    public bool EnqueueIfEligible(string board, int zeroLoc, int i) {
        var chars = board.ToCharArray();
        chars[zeroLoc] = chars[i];
        chars[i] = '0';
        var swapped = new string(chars);
        if(FINAL_BOARD == swapped) {
            result = sp[board] + 1;
            return true;
        }
        if(!sp.ContainsKey(swapped)) {
            sp[swapped] = sp[board] + 1;
            queue.Enqueue(swapped);
        }
        return false;
    }
}