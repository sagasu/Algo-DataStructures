namespace AlgoTest.LeetCode.Valid_Word;

public class Valid_Word
{
    public bool IsValid(string word) {
        if(word.Length > 2){
            string vowel = "aeiouAEIOU";
            bool isV = false, isC = false;
            foreach(char w in word){
                if(!char.IsLetterOrDigit(w)){
                    return false;
                }
                else{
                    if(vowel.Contains(w)){
                        isV = true;
                    }
                    else if(char.IsLetter(w) && !vowel.Contains(w)){
                        isC = true;
                    }
                }
            }
            return isV && isC;
        }
        return false;
    }
}