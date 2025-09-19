namespace AlgoTest.LeetCode.Design_Spreadsheet;

public class Spreadsheet
{
    private int[,] grid;
    public Spreadsheet(int rows) {
        grid = new int[rows, 26];
    }
    
    public void SetCell(string cell, int value) {
        var pos = ParseCell(cell);
        grid[pos.Item1, pos.Item2] = value;
    }
    
    public void ResetCell(string cell) {
        var pos = ParseCell(cell);
        grid[pos.Item1, pos.Item2] = 0;
    }
    
    public int GetValue(string formula) {
        string expr = formula.Substring(1); 
        string[] parts = expr.Split('+');

        return Evaluate(parts[0]) + Evaluate(parts[1]);
    }
    private int Evaluate(string operand) {
        if (char.IsDigit(operand[0])) {
            return int.Parse(operand);
        } else {
            var pos = ParseCell(operand);
            return grid[pos.Item1, pos.Item2];
        }
    }

    private (int, int) ParseCell(string cell) {
        char colChar = cell[0];
        int col = colChar - 'A';
        int row = int.Parse(cell.Substring(1)) - 1;
        return (row, col);
    }
}