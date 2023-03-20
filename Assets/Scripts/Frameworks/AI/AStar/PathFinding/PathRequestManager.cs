namespace AStarAI.AStar.PathFinding
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(PathFinding))]
    public class PathRequestManager : MonoBehaviour
    {
        private static PathRequestManager instance;
        public bool IsProcessingPath { get; private set; }

        private Queue<PathRequest> _pathRequestQueue = new Queue<PathRequest>();
        private PathRequest currentPathRequest;
        private PathFinding pathfinding;

        private void Awake()
        {
            instance = this;
            pathfinding = GetComponent<PathFinding>();
        }

        public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback)
        {
            PathRequest newRequest = new PathRequest(pathStart, pathEnd, callback);
            instance._pathRequestQueue.Enqueue(newRequest);
            instance.TryProcessNext();
        }

        private void TryProcessNext()
        {
            if (!IsProcessingPath && _pathRequestQueue.Count > 0)
            {
                currentPathRequest = _pathRequestQueue.Dequeue();
                IsProcessingPath = true;
                pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
            }
        }

        public void FinishedProcessingPath(Vector3[] path, bool success)
        {
            currentPathRequest.callback(path, success);
            IsProcessingPath = false;
            TryProcessNext();
        }

        private struct PathRequest
        {
            public Vector3 pathStart;
            public Vector3 pathEnd;
            public Action<Vector3[], bool> callback;

            public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback)
            {
                pathStart = _start;
                pathEnd = _end;
                callback = _callback;
            }
        }
    }
}