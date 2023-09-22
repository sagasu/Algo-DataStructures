namespace AlgoTest.LeetCode.Bulls_and_Cows;

public class Bulls_and_Cows
{
    public string GetHint(string secret, string guess) {
        var cowsCount = 0;
        var bullsCount = 0;
        var secretsCount = new int[10];
        
        foreach (var t in secret)
            secretsCount[t-'0']++;
        
        
        for(var i=0; i<secret.Length; i++){
            if(secret[i] == guess[i]){
                bullsCount++;
                
                if(secretsCount[secret[i]-'0'] <= 0)
                    cowsCount -= 1;
                else
                    secretsCount[secret[i]-'0']--;
                
            } else if(secretsCount[guess[i]-'0'] > 0){
                cowsCount++;                    
                secretsCount[guess[i]-'0']--;
            }
        }
        
        return string.Format($"{bullsCount}A{cowsCount}B");
    }
}