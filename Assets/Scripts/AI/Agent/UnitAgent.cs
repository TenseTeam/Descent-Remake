
namespace AI.Agents
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using AI.PathFinding;

    public class UnitAgent : MonoBehaviour
    {
        public Transform target;
        public float speed = 5f;

        private Vector3[] _agentPath;
        private int _targetIndex;

        private void Start()
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }

        public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
        {
            if (pathSuccessful)
            {
                _agentPath = newPath;
                StopCoroutine("FollowPath");
                StartCoroutine("FollowPath");
            }
        }

        private IEnumerator FollowPath()
        {
            Vector3 currentWaypoint = _agentPath[0];

            while (true)
            {
                if (transform.position == currentWaypoint)
                {
                    _targetIndex++;
                    if(_targetIndex >= _agentPath.Length)
                    {
                        yield break;
                    }

                    currentWaypoint = _agentPath[_targetIndex];

                    transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed);
                    yield return null;
                }
            }
        }
    }
}
