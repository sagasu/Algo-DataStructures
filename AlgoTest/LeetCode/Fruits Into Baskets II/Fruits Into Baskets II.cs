namespace AlgoTest.LeetCode.Fruits_Into_Baskets_II;

public class Fruits_Into_Baskets_II
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        for(int i=0;i<fruits.Length;i++){
            for(int j=0;j<baskets.Length;j++){
                if(baskets[j]>-1&&baskets[j]>=fruits[i]){
                    baskets[j]=-1;
                    fruits[i]=-1;
                    break;
                }
            }
        }
        int ans=0;
        foreach(var u in fruits){
            if(u!=-1){
                ans++;
            }
        }
        return ans;
    }
}