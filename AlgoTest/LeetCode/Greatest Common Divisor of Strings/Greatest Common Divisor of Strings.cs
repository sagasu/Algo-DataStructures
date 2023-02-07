public class GreatestCommonDivisorofStrings {
    public string GcdOfStrings(string str1, string str2)  => 
        str1 + str2 == str2 + str1 ? str1.Substring(0, Gcd(str1.Length, str2.Length)) : string.Empty;

    private static int Gcd(int x, int y) => y == 0 ? x : Gcd(y, x % y);
}