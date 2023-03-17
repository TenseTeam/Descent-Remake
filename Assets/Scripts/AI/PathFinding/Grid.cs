
namespace AI.PathFinding
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class Grid : MonoBehaviour
    {
        public LayerMask unwalkableMask;
        public Vector2 gridWorldSize;
        public float nodeRadius;

        private Node[,] _grid;

        private float _nodeDiameter;
        private int gridSizeX, gridSizeY;

        public int MaxGridSize => gridSizeX * gridSizeY;

        private void Awake()
        {
            _nodeDiameter = nodeRadius * 2f;
            gridSizeX = Mathf.RoundToInt(gridWorldSize.x / _nodeDiameter);
            gridSizeY = Mathf.RoundToInt(gridWorldSize.y / _nodeDiameter);

            CreateGrid();
        }

        private void CreateGrid()
        {
            _grid = new Node[gridSizeX, gridSizeY];
            Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y/2;

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * _nodeDiameter + nodeRadius) + Vector3.forward * (y * _nodeDiameter + nodeRadius);
                    bool walkable = !Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask);
                    _grid[x, y] = new Node(walkable, worldPoint, x, y);
                }
            }
        }

        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbours.Add(_grid[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }

        public Node NodeFromWorldPoint(Vector3 worldPoint)
        {
            float percentX = (worldPoint.x + gridWorldSize.x / 2) / gridWorldSize.x;
            float percentY = (worldPoint.z + gridWorldSize.y / 2) / gridWorldSize.y;

            percentX = Mathf.Clamp01(percentX); // if the worldposition it is outside of the grid, it doesnt give an invalid value
            percentY = Mathf.Clamp01(percentY);

            int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
            int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

            return _grid[x, y];
        }

#if DEBUG
        void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 0, gridWorldSize.y));

            if(_grid != null)
            {
                foreach(Node node in _grid)
                {
                    Gizmos.color = node.isWalkable ? Color.white : Color.red;
                    Gizmos.DrawCube(node.worldPosition, Vector3.one * (_nodeDiameter - .1f));
                }
            }
        }
#endif
    }
}
