namespace AStarAI.AStar.PathFinding
{
    using AStarAI.Data.Structures;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(PathRequestManager), typeof(PathGrid))]
    public class PathFinding : MonoBehaviour
    {
        private PathRequestManager _requestManager;
        private PathGrid _grid;

        private void Awake()
        {
            _requestManager = GetComponent<PathRequestManager>();
            _grid = GetComponent<PathGrid>();
        }

        public void StartFindPath(Vector3 startPos, Vector3 targetPos)
        {
            StartCoroutine(FindPath(startPos, targetPos));
        }

        private IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
        {
            Vector3[] waypoints = new Vector3[0];
            bool pathSuccess = false;

            Node startNode = _grid.NodeFromWorldPoint(startPos);
            Node targetNode = _grid.NodeFromWorldPoint(targetPos);

            if (startNode.IsWalkable && targetNode.IsWalkable)
            {
                Heap<Node> openSet = new Heap<Node>(_grid.GridMaxSize);
                HashSet<Node> closedSet = new HashSet<Node>();
                openSet.Add(startNode);

                while (openSet.Count > 0)
                {
                    Node currentNode = openSet.RemoveFirst();
                    closedSet.Add(currentNode);

                    if (currentNode == targetNode)
                    {
                        pathSuccess = true;
                        break;
                    }

                    foreach (Node neighbour in _grid.GetNeighbours(currentNode))
                    {
                        if (!neighbour.IsWalkable || closedSet.Contains(neighbour))
                        {
                            continue;
                        }

                        int newMovementCostToNeighbour = currentNode.GCost + GetDistance(currentNode, neighbour);
                        if (newMovementCostToNeighbour < neighbour.GCost || !openSet.Contains(neighbour))
                        {
                            neighbour.GCost = newMovementCostToNeighbour;
                            neighbour.HCost = GetDistance(neighbour, targetNode);
                            neighbour.parent = currentNode;

                            if (!openSet.Contains(neighbour))
                                openSet.Add(neighbour);
                        }
                    }
                }
            }

            yield return null;

            if (pathSuccess)
            {
                waypoints = RetracePath(startNode, targetNode);
            }

            _requestManager.FinishedProcessingPath(waypoints, pathSuccess);
        }

        private Vector3[] RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = endNode;

            path.Add(startNode);
            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }

            Vector3[] waypoints = SimplifyPath(path);
            Array.Reverse(waypoints);
            return waypoints;
        }

        private Vector3[] SimplifyPath(List<Node> path)
        {
            List<Vector3> waypoints = new List<Vector3>();
            Vector3 directionOld = Vector3.zero;

            for (int i = 1; i < path.Count; i++)
            {
                Vector3 directionNew = path[i - 1].GridPosition - path[i].GridPosition;

                if (directionNew != directionOld)
                {
                    waypoints.Add(path[i].worldPosition);
                }

                directionOld = directionNew;
            }
            return waypoints.ToArray();
        }

        private int GetDistance(Node nodeA, Node nodeB) => Mathf.RoundToInt(Vector3.Distance(nodeA.GridPosition, nodeB.GridPosition) * 10f);
    }
}