using System.Collections.Generic;

namespace AlgoTest.LeetCode.Implement_Router;

public class Router
{
    private record PacketInfo(int Source, int Destination, int Timestamp);
    private class PacketList
    {
        public List<PacketInfo> Items { get; set; } = [];
        public int StartPosition { get; private set; } = 0;

        public void Forward()
        {
            StartPosition++;
        }
    }

    private Queue<PacketInfo> _sortedSet;
    private HashSet<PacketInfo> _packets;
    private Dictionary<int, PacketList> _destinationPackets;
    private int _memoryLimit;

    public Router(int memoryLimit)
    {
        _memoryLimit = memoryLimit;
        _packets = new();
        _sortedSet = new();
        _destinationPackets = new Dictionary<int, PacketList>();
    }
    
    public bool AddPacket(int source, int destination, int timestamp)
    {
        var newPacket = new PacketInfo(source, destination, timestamp);
        if (_packets.Contains(newPacket))
        {
            return false;
        }

        if (!_destinationPackets.ContainsKey(destination))
        {
            _destinationPackets[destination] = new PacketList();
        }
        _destinationPackets[destination].Items.Add(newPacket);

        _packets.Add(newPacket);
        _sortedSet.Enqueue(newPacket);

        if (_memoryLimit < _sortedSet.Count)
        {
            ForwardPacket();
        }

        return true;
    }
    
    public int[] ForwardPacket()
    {
        if (_sortedSet.Count is 0)
            return [];

        var forwardPacket = _sortedSet.Peek();
        _packets.Remove(forwardPacket);
        _sortedSet.Dequeue();

        _destinationPackets[forwardPacket.Destination].Forward();

        return
        [
            forwardPacket.Source, forwardPacket.Destination, forwardPacket.Timestamp
        ];
    }
    
    public int GetCount(int destination, int startTime, int endTime)
    {
        if (!_destinationPackets.ContainsKey(destination))
        {
            return 0;
        }
        
        var packets = _destinationPackets[destination];
        if (packets.Items.Count is 0 ||
            packets.Items.Count == packets.StartPosition)
        {
            return 0;
        }
        
        var left = packets.StartPosition;
        var right = _destinationPackets[destination].Items.Count - 1;

        var leftBoundary = GetDestinationLeftBoundary(destination, left, right, startTime);
        var rightBoundary = GetDestinationRightBoundary(destination, left, right, endTime);

        return leftBoundary is -1 || rightBoundary is -1 ? 0 : rightBoundary - leftBoundary + 1;
    }

    private int GetDestinationLeftBoundary(int destination, int left, int right, int startTime)
    {
        var packets = _destinationPackets[destination].Items;
        var leftBoundary = -1;
        
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (packets[mid].Timestamp >= startTime)
            {
                leftBoundary = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return leftBoundary;
    }

    private int GetDestinationRightBoundary(int destination, int left, int right, int endTime)
    {
        var packets = _destinationPackets[destination].Items;
        var rightBoundary = -1;
        
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (packets[mid].Timestamp <= endTime)
            {
                rightBoundary = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return rightBoundary;
    }
}