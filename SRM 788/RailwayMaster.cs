using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

public class RailwayMaster {
	public int maxProfit(int N, int M, int K, int[] a, int[] b, int[] v) {
        var railways = new Railway[M];
        for (int i = 0; i < railways.Length; i++)
        {
            railways[i] = new Railway(a[i], b[i], v[i]);
        }
        Array.Sort(railways);
        var queue = new Queue<Railway>(railways);
        var needed = new Queue<Railway>();

        var count = 0;
        var result = 0;

        while (queue.Count > 1 && count < K)
        {
            var unionFind = new UnionFindTree(N);

            var trying = queue.Dequeue();

            foreach (var railway in needed)
            {
                unionFind.Unite(railway.CityA, railway.CityB);
            }

            foreach (var railway in queue)
            {
                unionFind.Unite(railway.CityA, railway.CityB);
            }

            if (unionFind.Groups == 1)
            {
                result += trying.Cost;
                count++;
            }
            else
            {
                needed.Enqueue(trying);
            }
        }

        return result;
    }

    [StructLayout(LayoutKind.Auto)]
    struct Railway : IComparable<Railway>
    {
        public int CityA;
        public int CityB;
        public int Cost;

        public Railway(int cityA, int cityB, int cost)
        {
            CityA = cityA;
            CityB = cityB;
            Cost = cost;
        }

        public int CompareTo(Railway other)
        {
            return other.Cost - Cost;
        }
    }

    public class UnionFindTree
    {
        private UnionFindNode[] _nodes;
        public int Count
        {
            get
            {
                return _nodes.Length;
            }
        }
        public int Groups;

        public UnionFindTree(int count)
        {
            _nodes = Enumerable.Range(0, count).Select(i => new UnionFindNode(i)).ToArray();
            Groups = _nodes.Length;
        }

        public void Unite(int index1, int index2)
        {
            var succeed = _nodes[index1].Unite(_nodes[index2]);
            if (succeed)
            {
                Groups--;
            }
        }

        public bool IsInSameGroup(int index1, int index2)
        {
            return _nodes[index1].IsInSameGroup(_nodes[index2]);
        }
        public int GetGroupSizeOf(int index)
        {
            return _nodes[index].GetGroupSize();
        }

        private class UnionFindNode
        {
            private int _height;        // rootÇÃÇ∆Ç´ÇÃÇ›óLå¯
            private int _groupSize;     // ìØè„
            private UnionFindNode _parent;
            public int ID;

            public UnionFindNode(int id)
            {
                _height = 0;
                _groupSize = 1;
                _parent = this;
                ID = id;
            }

            public UnionFindNode FindRoot()
            {
                if (_parent != this) // not ref equals
                {
                    var root = _parent.FindRoot();
                    _parent = root;
                }

                return _parent;
            }

            public int GetGroupSize()
            {
                return FindRoot()._groupSize;
            }

            public bool Unite(UnionFindNode other)
            {
                var thisRoot = this.FindRoot();
                var otherRoot = other.FindRoot();

                if (thisRoot == otherRoot)
                {
                    return false;
                }

                if (thisRoot._height < otherRoot._height)
                {
                    thisRoot._parent = otherRoot;
                    otherRoot._groupSize += thisRoot._groupSize;
                    otherRoot._height = Math.Max(thisRoot._height + 1, otherRoot._height);
                    return true;
                }
                else
                {
                    otherRoot._parent = thisRoot;
                    thisRoot._groupSize += otherRoot._groupSize;
                    thisRoot._height = Math.Max(otherRoot._height + 1, thisRoot._height);
                    return true;
                }
            }

            public bool IsInSameGroup(UnionFindNode other)
            {
                return this.FindRoot() == other.FindRoot();
            }
        }
    }

}
