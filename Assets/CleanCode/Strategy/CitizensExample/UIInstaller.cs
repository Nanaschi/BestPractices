using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{

    [SerializeField] private CitizensView _citizensView;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_citizensView).AsSingle();
    }
}
