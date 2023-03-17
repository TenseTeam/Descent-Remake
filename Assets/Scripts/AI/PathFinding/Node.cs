
namespace AI.PathFinding
{
    using UnityEngine;
    using System.Linq;

    public class Node : IHeapItem<Node>
    {
        public bool isWalkable;
        public Vector3 worldPosition;
        public int gridX;
        public int gridY;

        public int gCost;
        public int hCost;

        public Node parent;

        public int FCost => gCost + hCost;

        private int heapIndex;

        public int HeapIndex
        {
            get
            {
                return heapIndex;
            }
            set
            {
                heapIndex = value;
            }
        }

        public Node(bool isWalkable, Vector3 worldPosition, int gridX, int gridY)
        {
            this.isWalkable = isWalkable;
            this.worldPosition = worldPosition;
            this.gridX = gridX;
            this.gridY = gridY;
        }

        public int CompareTo(Node other)
        {
            int compare = FCost.CompareTo(other.FCost);

            if(compare == 0)
            {
                compare = hCost.CompareTo(other.hCost);
            }

            return -compare;
        }
    }
}