public class Permutations {
    public IList<IList<int>> Permute(int[] nums) {
        var n = nums.Length;

        var result = new List<IList<int>>();
        if (n == 0) return result;

        DFS(nums, new bool[n], new List<int>(), result);

        return result;
    }

    private void DFS(int[] nums, bool[] isVisited, IList<int> oneResult, IList<IList<int>> result) {
        var n = nums.Length;

        if (oneResult.Count == n) {
            result.Add(new List<int>(oneResult));
        } else {
            for (int i = 0; i < n; i++) {
                if (isVisited[i]) continue;

                oneResult.Add(nums[i]);
                isVisited[i] = true;
                DFS(nums, isVisited, oneResult, result);
                isVisited[i] = false;
                oneResult.RemoveAt(oneResult.Count - 1);
            }
        }
    }
}