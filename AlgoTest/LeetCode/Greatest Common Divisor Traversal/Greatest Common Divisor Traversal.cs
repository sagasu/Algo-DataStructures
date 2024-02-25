using System.Collections.Generic;

namespace AlgoTest.LeetCode.Greatest_Common_Divisor_Traversal;

public class Greatest_Common_Divisor_Traversal
{
    class UnionFind {
        private readonly int[] _par;
        private readonly int[] _size;
        public int count;

        public UnionFind(int n){
            count = n;
            _par = new int[n];
            _size = new int[n];
            for(var i=0;i<n;i++){
                _par[i]=i;
                _size[i]=1;
            }
        }

        private int Find(int n){
            if(n!=_par[n])
                _par[n] = Find(_par[n]);
            
            return _par[n];
        }

        public void Union(int x, int y){
            var px = Find(x);
            var py = Find(y);
            
            if(px==py)
                return;
            
            if(_size[px]<_size[py]){
                _par[px] = py;
                _size[py] += _size[px];
            }
            else{
                _par[py] = px;
                _size[px] += _size[py];
            }
            
            count--;
        }
    }
    
    public bool CanTraverseAllPairs(int[] nums) {
        var n = nums.Length;
        var uf = new UnionFind(n);
        var primeToIndex = new Dictionary<int, int>();

        for (var i = 0; i < n; i++) {
            var primes = PrimeFactors(nums[i]);
            foreach (var prime in primes) {
                if (!primeToIndex.ContainsKey(prime))
                    primeToIndex[prime] = i;
                else
                    uf.Union(i, primeToIndex[prime]);
            }
        }

        return uf.count == 1;
    }

    private List<int> PrimeFactors(int num) {
        var primes = new List<int>();
        for (var i = 2; i * i <= num; i++) {
            while (num % i == 0) {
                primes.Add(i);
                num /= i;
            }
        }
        if (num > 1)
            primes.Add(num);
        
        return primes;
    }
}