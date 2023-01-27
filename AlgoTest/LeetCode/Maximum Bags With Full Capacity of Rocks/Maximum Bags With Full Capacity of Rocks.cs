using System.Linq;

public class MaximumBagsSolution
{
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks) {
        return capacity
            .Zip(rocks, (cap, roc) => cap - roc )
            .OrderBy(x => x)
            .TakeWhile(x => (additionalRocks -= x) >= 0)
            .Count();
    }
}