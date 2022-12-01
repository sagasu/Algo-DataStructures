using System.Collections.Generic;

public class Solution23 {
    public bool UniqueOccurrences(int[] arr) {
        Dictionary<int, int> dic = new Dictionary<int, int>();

	for (int i = 0; i < arr.Length; i++)
	{
		if (dic.ContainsKey(arr[i]))
			dic[arr[i]]++;
		else
			dic.Add(arr[i], 1);
	}

	HashSet<int> set = new HashSet<int>();

	foreach (KeyValuePair<int, int> pair in dic)
	{
		if (set.Contains(pair.Value))
			return false;
		else
			set.Add(pair.Value);
	}

	return true;
    }
}