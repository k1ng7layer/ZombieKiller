using UnityEngine;

namespace Game.Utils
{
    public readonly struct TrajectoryInfo
    {
        public readonly Vector3[] Waypoints;
        public readonly int NextPoint;

        public TrajectoryInfo(Vector3[] waypoints, int nextPoint)
        {
            Waypoints = waypoints;
            NextPoint = nextPoint;
        }
    }
}