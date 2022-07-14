using Zenject;

public class GameSceneInstaller1 : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Market>().AsSingle();
    }

}
