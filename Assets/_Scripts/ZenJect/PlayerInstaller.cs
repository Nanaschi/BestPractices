using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Inputs))]
public class PlayerInstaller : MonoInstaller
{
   private Inputs _inputs;
    public override void InstallBindings()
    {
        UnityComponentsInitialization();
        Container.Bind<Inputs>().FromInstance(_inputs).AsSingle();
    }

    private void UnityComponentsInitialization()
    {
        _inputs = GetComponent<Inputs>();
    }
}
