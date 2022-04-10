using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.PlayerPrefs;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Inputs))]
public class GameSceneInstaller : MonoInstaller
{
   private Inputs _inputs;
   private GameEventsInject _gameEventsInject;
    public override void InstallBindings()
    {
        UnityComponentsInitialization();
        Container.Bind<Inputs>().FromInstance(_inputs).AsSingle();
        Container.Bind<GameEventsInject>().FromInstance(_gameEventsInject).AsSingle();
    }

    private void UnityComponentsInitialization()
    {
        _inputs = GetComponent<Inputs>();
        _gameEventsInject = GetComponent<GameEventsInject>();
    }
}
