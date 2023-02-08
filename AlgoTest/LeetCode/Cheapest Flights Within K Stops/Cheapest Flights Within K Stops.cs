using System;
using System.Collections.Generic;

public class FindCheapestPriceSolution
{
    private int minPrice = Int32.MaxValue;

    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        
        if(flights?.Length == 0) return 0;
        
        
        bar flightsMap = new Dictionary<int, List<GraphListNode>>();
        var price = new int[n];
        
        foreach(int[] flight in flights){

            if(!flightsMap.ContainsKey(flight[0])) flightsMap.Add(flight[0], new List<GraphListNode>());
            
            
            flightsMap[flight[0]].Add(new GraphListNode() {
                                           destination = flight[1],
                                           weight = flight[2]
                                       });
        }
        
        BFS(flightsMap, src, dst, k, price);
        
        return minPrice != Int32.MaxValue ? minPrice : -1;
    }
    
    private void BFS(Dictionary<int, List<GraphListNode>> flightsMap, int src, int dst, int k, int[] price){
        
        var queue = new Queue<QueueData>();
        
        queue.Enqueue(new QueueData{
            currentNode = src,
            hopTillNode = 0,
            priceTillNow = 0
        });
        
        while(queue.Count > 0){
            
            var queueData = queue.Dequeue();
            
            if(queueData.currentNode == dst) minPrice = Math.Min(minPrice, queueData.priceTillNow);
            else{
                
                var flights = flightsMap.ContainsKey(queueData.currentNode) ? flightsMap[queueData.currentNode] : new List<GraphListNode>();
        
                foreach(GraphListNode flight in flights) {
                    if(queueData.hopTillNode <= k && queueData.priceTillNow + flight.weight < minPrice
                        && (price[flight.destination] == 0 || price[flight.destination] > queueData.priceTillNow + flight.weight)){
                        
                        price[flight.destination] = queueData.priceTillNow + flight.weight;
                        
                        queue.Enqueue(
                            new QueueData{
                                    currentNode = flight.destination,
                                    hopTillNode = queueData.hopTillNode + 1,
                                    priceTillNow = queueData.priceTillNow + flight.weight
                                });   
                    }
                }   
            }
        }
    }
    
    class GraphListNode{
        public int destination;
        public int weight;
    }
    
    class QueueData{
        public int currentNode {get;set;}
        public int priceTillNow {get;set;}
        public int hopTillNode {get;set;}
    }
}