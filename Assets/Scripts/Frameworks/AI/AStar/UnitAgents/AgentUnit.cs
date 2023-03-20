namespace AStarAI.Agents
{
    using AStar.PathFinding;
    using System.Collections;
    using UnityEngine;

    public class AgentUnit : MonoBehaviour
    {
        [SerializeField]
        private float _movementSpeed = 10.0f;

        private Vector3[] _path;
        private int _targetIndex;

        public Transform Target { get; set; }
        public float PathUpdateFrequency { get; set; } = .5f;

        public void StartCalculatingPathAndMoveToTarget()
        {
            StopCalculatingPath();
            StartCoroutine(PathUpdate());
        }

        public void StopCalculatingPath()
        {
            StopAllCoroutines();
        }

        public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
        {
            if (pathSuccessful)
            {
                _path = newPath;
                _targetIndex = 0;
                StopCoroutine("FollowPath");
                StartCoroutine("FollowPath");
            }
        }

        private IEnumerator PathUpdate()
        {
            while (true)
            {
                // To optimize with extensions methods
                PathRequestManager.RequestPath(transform.position, Target.position, OnPathFound);
                yield return new WaitForSeconds(PathUpdateFrequency);
            }
        }

        private IEnumerator FollowPath()
        {
            if (_targetIndex >= _path.Length)
                yield break;

            Vector3 currentWaypoint = _path[_targetIndex];

            while (true)
            {
                if (transform.position == currentWaypoint)
                {
                    _targetIndex++;
                    if (_targetIndex >= _path.Length)
                    {
                        yield break;
                    }
                    currentWaypoint = _path[_targetIndex];
                }

                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, _movementSpeed * Time.deltaTime);
                yield return null;
            }
        }

#if DEBUG || UNITY_EDITOR

        [ContextMenu("Go To Target")]
        public void GoToTarget()
        {
            StartCalculatingPathAndMoveToTarget();
        }

        [ContextMenu("Stop Going To Target")]
        public void StopGoingToTarget()
        {
            StopCalculatingPath();
        }

        public void OnDrawGizmos()
        {
            if (_path != null)
            {
                for (int i = _targetIndex; i < _path.Length; i++)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawSphere(_path[i], 0.1f);

                    if (i == _targetIndex)
                    {
                        Gizmos.DrawLine(transform.position, _path[i]);
                    }
                    else
                    {
                        Gizmos.DrawLine(_path[i - 1], _path[i]);
                    }
                }
            }
        }

#endif
    }
}