using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectIntsallerContainer : MonoInstaller
{
    /*[SerializeField] private List<GameObject> _persistentGameObjects;

    public override void InstallBindings()
    {
        foreach (var persistentGameObject in _persistentGameObjects)
        {
            DontDestroyOnLoad(Instantiate(persistentGameObject));
        }
        
        
    }*/


    [SerializeField] private PersistentData _persistentData;
    public override void InstallBindings()
    {
        DontDestroyOnLoad(Instantiate(_persistentData));
        Container.Bind<PersistentData>().FromInstance(_persistentData.GetComponent<PersistentData>()).AsSingle();
    }
}
