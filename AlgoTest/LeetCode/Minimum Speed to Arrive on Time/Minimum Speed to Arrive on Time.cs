public class MinimumSpeedtoArriveonTime {
    public int MinSpeedOnTime(int[] dist, double hour) {
        int low = 1;
        int high = (int)Math.Pow(10,7);
        int result = -1;
        while(low<=high)
        {
            int mid = low + (high-low)/2;
            if(MSOT(mid,dist,hour))
            {
                result = mid;
                high = mid-1;
            }
            else
                low = mid+1;
        }
        return result;
    }

    private bool MSOT(int speed, int[] dist, double hour)
    {
        double time = 0;
        for(int i=0;i<dist.Length-1;i++)
            time += Math.Ceiling((double)dist[i]/(double)speed);
        time += (double)dist[dist.Length-1]/(double)speed;
        return time <= hour;
    }
}