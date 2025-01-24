public class SubstringWithLargestVariance {
    public int LargestVariance(string s) {
        int[] freq = new int[26];
        foreach(char ch in s) freq[ch-'a']++;
        int largestDiff = 0;
        for(char ch1 = 'a'; ch1 <= 'z'; ch1++){
            for(char ch2 = 'a'; ch2 <= 'z'; ch2++){
                if(ch1 == ch2 || freq[ch1-'a'] == 0 || freq[ch2-'a'] == 0) continue;
                int hiFreq = 0, loFreq = 0;
                foreach(char ch in s){
                    if(ch == ch1) hiFreq++;
                    if(ch == ch2) loFreq++;
                    if(loFreq > 0) largestDiff = Math.Max(largestDiff, hiFreq-loFreq);
                    if(hiFreq < loFreq){
                        hiFreq = 0;
                        loFreq = 0;
                    }
                }
                if(loFreq == 0) largestDiff = Math.Max(largestDiff, hiFreq-1);
            }
        }
        return largestDiff;
    }
}