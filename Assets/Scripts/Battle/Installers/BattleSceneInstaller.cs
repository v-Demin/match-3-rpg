using UnityEngine;
using Zenject;

public class BattleSceneInstaller : MonoInstaller
{
    [SerializeField] private BattleFieldModelControllCreator _creator;
    [SerializeField] private BattleField _battleField;
    [SerializeField] private CrystalField _crystalField;
    
    public override void InstallBindings()
    {
        Container.Bind<BattleFieldModelControllCreator>()
            .FromInstance(_creator)
            .AsSingle();
        
        Container.Bind<BattleField>()
            .FromInstance(_battleField)
            .AsSingle();
        
        Container.Bind<CrystalField>()
            .FromInstance(_crystalField)
            .AsSingle();
    }
}