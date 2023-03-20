namespace AStarAI.AStar.PathFinding
{
    using AStarAI.Data.Structures;
    using UnityEngine;

    public class Node : IHeapItem<Node>
    {
        public Node parent;
        public Vector3 worldPosition;

        public bool IsWalkable { get; set; }
        public Vector3Int GridPosition { get; private set; }
        public int HeapIndex { get; set; }
        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost => GCost + HCost;

        public Node(bool _walkable, Vector3 _worldPos, Vector3Int gridPosition)
        {
            IsWalkable = _walkable;
            worldPosition = _worldPos;
            GridPosition = gridPosition;
        }

        public int CompareTo(Node nodeToCompare)
        {
            int compare = FCost.CompareTo(nodeToCompare.FCost);
            if (compare == 0)
            {
                compare = HCost.CompareTo(nodeToCompare.HCost);
            }
            return -compare;
        }
    }
}