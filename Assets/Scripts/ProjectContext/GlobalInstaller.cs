using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BattleProvideService>()
            .AsSingle();
    }
}