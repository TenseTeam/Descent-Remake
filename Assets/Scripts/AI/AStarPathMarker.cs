
namespace AI.PathFinding
{
    using UnityEngine;
    using System.Linq;

    internal class PathNode
    {
        internal float g;
        internal float h;
        internal float f;
        internal PathNode parent;

        internal PathNode()
        {

        }
    }
}