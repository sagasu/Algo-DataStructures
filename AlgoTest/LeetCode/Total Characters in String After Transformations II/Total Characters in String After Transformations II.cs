using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Total_Characters_in_String_After_Transformations_II;

public class Total_Characters_in_String_After_Transformations_II
{
    private const ulong MOD = 1000000007;

    // Multiply 2 matrices and return result matrix
    private ulong[,] MultMM(ulong[,] AA, ulong[,] BB){
        ulong[,] RR = new ulong[26,26];
        for(int j = 0; j < 26; ++j){
            for(int i = 0 ; i < 26; ++i){
                ulong sum = 0;
                for(int k = 0; k < 26; ++k){
                    sum += AA[i,k] * BB[k,j];
                    sum = sum % MOD;
                }               
                RR[i,j] = sum;
            }
        }

        return RR;
    }

    public int LengthAfterTransformations(string s, int t, IList<int> nums) {

        // PP contains the production rules
        // Each row describes the production rule for a letter
        // For example 1: 
        // "abcyy"
        // [1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2]
        // Row 1 states that letter A and Z will produce an 'b'
        //       a b c ... x y z
        // 0 a   0 0 0     0 0 1
        // 1 b   1 0 0 ... 0 0 1
        ulong[,] PP = new ulong[26,26];
        Array.Clear(PP, 0, PP.Length);

        for(int i = 0 ; i < 26; ++i){
            for(int j = 1; j <= nums[i]; ++j){
                int k = (i+j) % 26;
                PP[k,i]=1;
            }
        }

        // CV contains the count vector
        // For example 1: "abcyy"
        //    a b c ... x y z
        // a  1 1 1     0 2 0

        ulong[] CV = new ulong[26];
        Array.Clear(CV,0,CV.Length);
        foreach(char ch in s){
            int i = ch-'a';
            CV[i]++;
        }

        // P x C = R1 (t=1)
        // P x P x C = P x R1 = R2 (t=2)
        // PxPx...xP x C = R(t)
        //quick matrix exponentiation by squaring
        ulong[,] EE = new ulong[26,26]; 
        // Start with identity matrix
        for (int i = 0; i < 26; i++) {
            EE[i, i] = 1;
        }

        while (t > 0) {
            if ((t & 1) == 1) {
                EE = MultMM(EE,PP);
            }
            PP = MultMM(PP, PP);
            t >>= 1;
        }
        
        // Sum up vector result from EE * CV 
        ulong ans = 0;
        for(int i = 0; i < 26; ++i){
            for(int j = 0; j < 26; ++j){
                ans +=  EE[i,j] * CV[j];
                ans = ans % MOD;
            }
        }

        return (int)ans;

    }
}