using UnityEngine;
using Zenject;

namespace ZenJect
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerControls _playerControls; //NonSerializable since it is interfaces
      
        public override void InstallBindings()
        {
            Container.Bind<PlayerControls>().FromInstance(_playerControls).AsSingle();
        }
    }
}