
namespace AI.PathFinding
{
    using UnityEngine;
    using System.Linq;

    internal class Node
    {
        internal bool isWalkable;
        internal Vector3 worldPosition;
        internal int gridX;
        internal int gridY;

        internal int gCost;
        internal int hCost;

        internal Node parent;

        internal int FCost => gCost + hCost;

        internal Node(bool isWalkable, Vector3 worldPosition, int gridX, int gridY)
        {
            this.isWalkable = isWalkable;
            this.worldPosition = worldPosition;
            this.gridX = gridX;
            this.gridY = gridY;
        }
    }
}