using System;
using Leopotam.Ecs;

    public sealed class MovementSystem: IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;

        private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> _movableEcsFilter = null;
        public void Run()
        {
            foreach (var i in _movableEcsFilter)
            {
                ref var modelComponent = ref _movableEcsFilter.Get1(i);
                ref var movableComponent = ref _movableEcsFilter.Get2(i);
                ref var directionComponent = ref _movableEcsFilter.Get3(i);


                ref var direction = ref directionComponent.Direction;
                ref var transform = ref modelComponent.ModelTransform;
                ref var speed = ref movableComponent.Speed;
                ref var characterController = ref movableComponent.CharacterController;
                
                var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);
                characterController.Move(rawDirection * speed);

            }
        }
    }