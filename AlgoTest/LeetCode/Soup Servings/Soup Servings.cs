public class SoupServingss {
    public double SoupServings(int n) {
        var probabilities = new double[5000, 5000];
        if (n >= 5000) return 1;
        
        return GetProbability(probabilities, (n+24)/25, (n+24)/25);
    }
    
    private double GetProbability(double[,] probabilities, int a, int b) {
        if (a <= 0 && b <= 0) return 0.5;
        
        if (a <= 0) return 1.0;
                
        if (b <= 0) return 0;
        
        if (probabilities[a,b] != 0) return probabilities[a,b];
                
        probabilities[a,b] = 0.25 * (GetProbability(probabilities, a-4, b) +
                             GetProbability(probabilities, a-3, b-1) +
                             GetProbability(probabilities, a-2, b-2) +
                             GetProbability(probabilities, a-1, b-3));
        
        return probabilities[a,b];
    }
}