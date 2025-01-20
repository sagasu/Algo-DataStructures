namespace AlgoTest.LeetCode.First_Completely_Painted_Row_or_Column;

public class First_Completely_Painted_Row_or_Column
{
    public int FirstCompleteIndex(int[] arr, int[][] mat) {
        var rowsCount = mat.Length;
        var columnsCount = mat[0].Length;
        var rowCounters = new int[rowsCount];
        var columnCounters = new int[columnsCount];

        var indexes = new Position[rowsCount * columnsCount];
        for (var i = 0; i < rowsCount; i++)
        {
            for (var j = 0; j < columnsCount; j++)
            {
                indexes[mat[i][j] - 1] = new Position { Row = i, Column = j };
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            var position = indexes[arr[i] - 1];
            var currentColumnsCount = ++rowCounters[position.Row];
            if (currentColumnsCount == columnsCount)
            {
                return i;
            }

            var currentRowsCount = ++columnCounters[position.Column];
            if (currentRowsCount == rowsCount)
            {
                return i;
            }
        }

        return arr.Length - 1;
    }

    private struct Position
    {
        public int Row;
        public int Column;
    }
}