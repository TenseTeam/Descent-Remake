namespace AStarAI.AStar.PathFinding
{
    using System.Collections.Generic;
    using UnityEngine;

    public class PathGrid : MonoBehaviour
    {
#if DEBUG || UNITY_EDITOR

        [Header("Gizmos")]
        public bool displayGridGizmos;

#endif

        [Header("Settings")]
        public LayerMask unwalkableMask;

        public Vector3 gridWorldSize;
        public float nodeRadius;

        private Node[,,] _grid;
        private float _nodeDiameter;

        private Vector3Int gridSize;
        public int GridMaxSize => gridSize.x * gridSize.y * gridSize.z;

        private void Awake()
        {
            if (gridSize.magnitude < 0f)
                gridSize = Vector3Int.one;

            _nodeDiameter = nodeRadius * 2;
            gridSize.x = Mathf.RoundToInt(gridWorldSize.x / _nodeDiameter);
            gridSize.y = Mathf.RoundToInt(gridWorldSize.y / _nodeDiameter);
            gridSize.z = Mathf.RoundToInt(gridWorldSize.z / _nodeDiameter);
            BuildGrid();
        }

        public void BuildGrid()
        {
            _grid = new Node[gridSize.x, gridSize.y, gridSize.z];
            Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2 - Vector3.forward * gridWorldSize.z / 2;

            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    for (int z = 0; z < gridSize.z; z++)
                    {
                        Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * _nodeDiameter + nodeRadius) + Vector3.up * (y * _nodeDiameter + nodeRadius) + Vector3.forward * (z * _nodeDiameter + nodeRadius);
                        bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                        _grid[x, y, z] = new Node(walkable, worldPoint, new Vector3Int(x, y, z));
                    }
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
                    for (int z = -1; z <= 1; z++)
                    {
                        if (x == 0 && y == 0 && z == 0)
                            continue;

                        int checkX = node.GridPosition.x + x;
                        int checkY = node.GridPosition.y + y;
                        int checkZ = node.GridPosition.z + z;

                        if (checkX >= 0 && checkX < gridSize.x
                            && checkY >= 0 && checkY < gridSize.y
                            && checkZ >= 0 && checkZ < gridSize.z)
                        {
                            neighbours.Add(_grid[checkX, checkY, checkZ]);
                        }
                    }
                }
            }

            return neighbours;
        }

        public Node NodeFromWorldPoint(Vector3 worldPosition)
        {
            float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
            float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;
            float percentZ = (worldPosition.z + gridWorldSize.z / 2) / gridWorldSize.z;

            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);
            percentZ = Mathf.Clamp01(percentZ);

            int x = Mathf.RoundToInt((gridSize.x - 1) * percentX);
            int y = Mathf.RoundToInt((gridSize.y - 1) * percentY);
            int z = Mathf.RoundToInt((gridSize.z - 1) * percentZ);
            return _grid[x, y, z];
        }

#if DEBUG || UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, gridWorldSize.z));
            if (_grid != null && displayGridGizmos)
            {
                Gizmos.color = Color.red;
                foreach (Node node in _grid)
                {
                    if (!node.IsWalkable)
                        Gizmos.DrawWireCube(node.worldPosition, Vector3.one * _nodeDiameter);
                }
            }
        }

        [ContextMenu("Build Grid")]
        private void RebuildGrid()
        {
            BuildGrid();
        }

#endif
    }
}