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


    [SerializeField] private PersistentDataInject persistentDataInject;
    public override void InstallBindings()
    {
        DontDestroyOnLoad(Instantiate(persistentDataInject));
        Container.Bind<PersistentDataInject>().FromInstance(persistentDataInject.GetComponent<PersistentDataInject>()).AsSingle();
    }
}
