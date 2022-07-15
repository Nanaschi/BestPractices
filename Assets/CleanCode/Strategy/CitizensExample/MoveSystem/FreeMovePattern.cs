using CleanCode.Strategy.CitizensExample.Interfaces;
using UnityEngine;

namespace CleanCode.Strategy.CitizensExample.MoveSystem
{
    public class FreeMovePattern: IMovable
    {
        private readonly Transform _transform;
        private readonly Vector3[] _randomPoints;

        FreeMovePattern(Transform transform, Vector3[] randomPoints)
        {
            _transform = transform;
            _randomPoints = randomPoints;
        }
        
        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}