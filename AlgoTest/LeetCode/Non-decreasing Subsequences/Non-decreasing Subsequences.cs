using System.Collections.Generic;

public class FindSubsequencesSolution
{
  public IList<IList<int>> FindSubsequences(int[] nums)
  {
    var ans = new List<IList<int>>();

    Traverse(nums, 0, new List<int>(), ans);

    return ans;
  }

  private void Traverse(int[] nums, int start, List<int> list, List<IList<int>> ans)
  {
    if (list.Count > 1)
      ans.Add(new List<int>(list));

    var set = new HashSet<int>();

    for (int i = start; i < nums.Length; i++)
    {
      if (list.Count > 0 && nums[i] < list[list.Count - 1])
        continue;

      if (set.Contains(nums[i]))
        continue;

      list.Add(nums[i]);

      Traverse(nums, i + 1, list, ans);

      list.RemoveAt(list.Count - 1);
      set.Add(nums[i]);
    }
  }
}