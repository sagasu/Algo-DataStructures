using System.Collections;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_the_Number_of_Complete_Components;

public class Count_the_Number_of_Complete_Components
{
    public class Network {
        public readonly BitArray vertices;
        public int vertexCount=2, edgeCount=1; // defaults for new
        public Network(BitArray vertices) => this.vertices=vertices;
    }

    public int CountCompleteComponents(int n, int[][] edges) {
        int unreferencedVertices=n;
        List<Network> networks=new();
        // for each edge
        for(int j=0; j<edges.Length; j++) {
            var e=edges[j];
            int n0=e[0], n1=e[1];
            // find the network index for each vertex
            int ni0=-1, ni1=-1;
            for(int i=0; i<networks.Count; i++) {
                BitArray ba=networks[i].vertices;
                if(ba[n0]) { ni0=i; if(ni1!=-1) break; }
                if(ba[n1]) { ni1=i; if(ni0!=-1) break; }
            }
            if(ni0<0 && ni1<0) { // if neither vertex is found
                BitArray ba=new(n);
                ba[n0]=ba[n1]=true;
                networks.Add(new(ba));
                unreferencedVertices-=2;
            } else if(ni0<0) { // if we are adding a vertex to the network
                Network net=networks[ni1];
                net.vertices[n0]=true;
                net.vertexCount++;
                net.edgeCount++;
                unreferencedVertices--;
            } else if(ni1<0) { // if we are adding a vertex to the network
                Network net=networks[ni0];
                net.vertices[n1]=true;
                net.vertexCount++;
                net.edgeCount++;
                unreferencedVertices--;
            } else if(ni0==ni1) { // if the vertices are on the same network
                networks[ni0].edgeCount++;
            } else { // if we need to join networks
                Network net0=networks[ni0], net1=networks[ni1];
                net0.vertices.Or(net1.vertices);
                net0.vertexCount+=net1.vertexCount;
                net0.edgeCount+=net1.edgeCount+1;
                // we want to delete ni1, but it should be faster to put the last element there and delete the last element
                int last=networks.Count-1;
                networks[ni1]=networks[last];
                networks.RemoveAt(last);
            }
        }
        int networkCount=unreferencedVertices;
        for(int i=0; i<networks.Count; i++) {
            Network net=networks[i];
            int vc=net.vertexCount, edgesOnFullyConnectedGraph=vc*(vc-1)>>1;
            if(edgesOnFullyConnectedGraph==net.edgeCount) networkCount++;
        }
        return networkCount;
    }
}