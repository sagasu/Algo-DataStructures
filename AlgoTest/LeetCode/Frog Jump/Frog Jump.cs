using System.Collections.Generic;

namespace AlgoTest.LeetCode.Frog_Jump;

public class Frog_Jump
{
    private Dictionary<StoneAndJump, bool> _cache = new();

    public bool CanCross(int[] stones)
    {
        return Jump(stones, 0, 1);
    }

    private bool Jump(int[] stones, int stoneIndex, int jumpLength)
    {
        if (_cache.TryGetValue(new StoneAndJump(stoneIndex, jumpLength), out bool cachedResult))
            return cachedResult;

        var nextIndex = NextStoneIndex(stones, stoneIndex, jumpLength);
        bool result;
        if (nextIndex == null)
            result = false;
        else if (nextIndex == stones.Length - 1)
            result = true;
        else
            result = Jump(stones, nextIndex.Value, jumpLength + 1)
                     || Jump(stones, nextIndex.Value, jumpLength)
                     || Jump(stones, nextIndex.Value, jumpLength - 1);

        _cache.Add(new StoneAndJump(stoneIndex, jumpLength), result);
        return result;
    }

    private int? NextStoneIndex(int[] stones, int stoneIndex, int jumpLength)
    {
        if (jumpLength <= 0)
            return null;
        var start = stones[stoneIndex];
        while (stoneIndex < stones.Length && stones[stoneIndex] - start < jumpLength)
            stoneIndex++;

        return stoneIndex < stones.Length && stones[stoneIndex] - start == jumpLength ? stoneIndex : (int?) null;
    }

    public struct StoneAndJump
    {
        public int StoneIndex;
        public int JumpLength;

        public StoneAndJump(int stoneIndex, int jumpLength)
        {
            StoneIndex = stoneIndex;
            JumpLength = jumpLength;
        }
    }
}