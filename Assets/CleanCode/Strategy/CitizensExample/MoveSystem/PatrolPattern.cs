using CleanCode.Strategy.CitizensExample.Interfaces;
using UnityEngine;

namespace CleanCode.Strategy.CitizensExample.MoveSystem
{
    public class PatrolPattern: IMovable
    {
        private readonly Transform _transform;
        private readonly Vector3[] _patrolPoints;


        public PatrolPattern(Transform transform, Vector3[] patrolPoints)
        {
            _transform = transform;
            _patrolPoints = patrolPoints;
        }

        public string Move()
        {
            return "Patrol Move";
        }
    }
}