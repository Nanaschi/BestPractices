using System;
using Leopotam.Ecs;
using UnityEngine;


public sealed class PlayerInputSystem: IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionEcsFilter = null;
        private float moveY;
        private float moveX;

        public void Run()
        {

            SetDirection();
            
            foreach (var i in _directionEcsFilter)
            {
                ref var directionComponent = ref _directionEcsFilter.Get2(i);

                ref var direction = ref directionComponent.Direction;

                direction.x = moveX;
                direction.y = moveY;

            }
        }


        private void SetDirection()
        {
            
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");
        }
        
    }