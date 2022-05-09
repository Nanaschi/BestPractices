using System;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public partial class ECSGameStartUp : MonoBehaviour
{
    private EcsWorld _ecsWorld;
    private EcsSystems _ecsSystems;
    public void Start()
    {
        _ecsWorld = new EcsWorld();
        _ecsSystems = new EcsSystems(_ecsWorld);

        _ecsSystems.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();
        
        _ecsSystems.Init();
    }

    private void AddOneFrames()
    {
        throw new NotImplementedException();
    }

    private void AddInjections()
    {
        throw new NotImplementedException();
    }

    private void AddSystems()
    {
        
    }

    private void Update()
    {
        _ecsSystems.Run();
    }

    private void OnDestroy()
    {
        if (_ecsSystems == null) return;
        
        _ecsSystems.Destroy();
        _ecsSystems = null;
        _ecsWorld.Destroy();
        _ecsWorld = null;
    }
}
