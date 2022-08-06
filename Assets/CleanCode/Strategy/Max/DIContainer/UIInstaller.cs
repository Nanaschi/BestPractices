using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{

    [SerializeField] private CitizensView _citizensView;
    [SerializeField] private PlayerView _playerView;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_citizensView).AsSingle();
        Container.BindInstance(_playerView).AsSingle();
    }
}