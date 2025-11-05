using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_X_Sum_of_All_K_Long_Subarrays_II;

public class Find_X_Sum_of_All_K_Long_Subarrays_II
{
    Dictionary<long, long> OccurenceTracker = new();
	SortedSet<Entry> LowOccurenceNumbers = new SortedSet<Entry>();
	SortedSet<Entry> HighOccurenceNumbers = new SortedSet<Entry>();
	private long GlobalSum = 0;

	class Entry(long OccurenceParam, long NumberParam) : IComparable<Entry>
	{
		public long Occurence { get; init; } = OccurenceParam;
		public long Number { get; init; } = NumberParam;
		public long Value = OccurenceParam * NumberParam;

		public int CompareTo(Entry? other)
		{
			int left = 1;
			int right = -1;
			if (other == null)
				return 0;
			if (this.Occurence == other.Occurence)
			{
				if (this.Number == other.Number)
					return 0;
				else if (this.Number > other.Number)
					return left;
				return right;
			}
			else if (other.Occurence < this.Occurence)
				return left;
			else
				return right;
		}
	}

	public long[] FindXSum(int[] nums, int k, int x)
	{
		int answerLength = nums.Length - k + 1;
		long[] answers = new long[answerLength];

		for (int i = 0; i < nums.Length; i++)
			OccurenceTracker[nums[i]] = 0;

		for (int i = 0; i < k; i++)
			OccurenceTracker[nums[i]]++;

		foreach (var entry in OccurenceTracker)
			LowOccurenceNumbers.Add(new Entry(entry.Value, entry.Key));

		BalanceSets(x);
		answers[0] = GlobalSum;

		for (int i = 1; i < answers.Length; i++)
		{
			UpdateSetsAndOccurence(nums[i - 1], -1);
			UpdateSetsAndOccurence(nums[i + k - 1], 1);
			BalanceSets(x);
			answers[i] = GlobalSum;
		}

		return answers;
	}

	private void UpdateSetsAndOccurence(int number, int summand)
	{
		var entry = new Entry(OccurenceTracker[number], number);
		OccurenceTracker[number] += summand;
		var newEntry = new Entry(OccurenceTracker[number], number);

		if (HighOccurenceNumbers.Contains(entry))
		{
			HighOccurenceRemove(entry);
			HighOccurenceAdd(newEntry);
		}
		else
		{
			LowOccurenceNumbers.Remove(entry);
			LowOccurenceNumbers.Add(newEntry);
		}
	}

	private void HighOccurenceAdd(Entry entry)
	{
		HighOccurenceNumbers.Add(entry);
		GlobalSum += entry.Value;
	}

	private void HighOccurenceRemove(Entry entry)
	{
		HighOccurenceNumbers.Remove(entry);
		GlobalSum -= entry.Value;
	}

	private void BalanceSets(int x)
	{
		while (HighOccurenceNumbers.Count < x && LowOccurenceNumbers.Count > 0)
		{
			var element = LowOccurenceNumbers.Max!;
			HighOccurenceAdd(element);
			LowOccurenceNumbers.Remove(element);
		}

		if (LowOccurenceNumbers.Count == 0)
			return;

		while (true)
		{
			var lowOccurenceElement = LowOccurenceNumbers.Max!;
			var highOccurenceElement = HighOccurenceNumbers.Min!;

			if (highOccurenceElement.Occurence < lowOccurenceElement.Occurence ||
				(lowOccurenceElement.Occurence == highOccurenceElement.Occurence &&
				highOccurenceElement.Number < lowOccurenceElement.Number))
			{
				LowOccurenceNumbers.Remove(lowOccurenceElement);
				HighOccurenceAdd(lowOccurenceElement);
				HighOccurenceRemove(highOccurenceElement);
				LowOccurenceNumbers.Add(highOccurenceElement);
			}
			else
				break;
		}
	}
}