namespace AlgoTest.LeetCode.Lemonade_Change;

public class Lemonade_Change
{
    public bool LemonadeChange(int[] bills) {
        var (numberOf5, numberOf10) = (0, 0);
        foreach(var bill in bills) {
            (numberOf5, numberOf10) = bill switch {
                5 => (numberOf5 + 1, numberOf10),
                10 => (numberOf5 - 1, numberOf10 + 1),
                20 when numberOf10 == 0 => (numberOf5 - 3, 0),
                _ => (numberOf5 - 1, numberOf10 - 1)
            };

            if (numberOf5 < 0 || numberOf10 < 0) {
                return false;
            }
        }

        return true;
    }
}