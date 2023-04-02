public class Successful PairsofSpellsandPotions {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions);
        var result = new int [spells.Length];

        for(var i=0; i< spells.Length; i++)
        {
            long min = success%spells[i] == 0 ? (success/spells[i]) : success/spells[i] + 1;
            var closes = BinarySearch (potions, 0, potions.Length - 1, min);;
            result[i] =(int) (closes);
        }

        return result;
    }
    

    
    
    public int BinarySearch (int[] arr, int low, int high, long key) {
       if(key < arr[0])  return arr.Length ;
       if(key > arr[arr.Length -1]) return 0;

        while (low < high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] == key) high = mid;
            if (arr[mid] < key) low = mid + 1;
            else high = mid;
        }
        
        return arr.Length -  high;
	}
	
}