using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Inputs))]
public class PlayerInstaller : MonoInstaller
{
   private Inputs _inputs;
   private GameEvents _gameEvents;
    public override void InstallBindings()
    {
        UnityComponentsInitialization();
        Container.Bind<Inputs>().FromInstance(_inputs).AsSingle();
        Container.Bind<GameEvents>().FromInstance(_gameEvents).AsSingle();
    }

    private void UnityComponentsInitialization()
    {
        _inputs = GetComponent<Inputs>();
        _gameEvents = GetComponent<GameEvents>();
    }
}
