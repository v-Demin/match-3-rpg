using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BattleFieldModelControllCreator : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;
    
    private readonly Dictionary<ClassId, Type> _classesTypes = new()
    {
        {ClassId.Alchemist, typeof(AlchemistBattleFieldControls)},
        {ClassId.Barbarian, typeof(BarbarianBattleFieldControls)},
        {ClassId.Berserk, typeof(BerserkBattleFieldControls)},
        {ClassId.Bomber, typeof(BomberBattleFieldControls)},
        {ClassId.Demon, typeof(DemonBattleFieldControls)},
        {ClassId.Mage, typeof(MageBattleFieldControls)},
        {ClassId.Summoner, typeof(SummonerBattleFieldControls)},
        {ClassId.Warrior, typeof(WarriorBattleFieldControls)},
        {ClassId.HammererArchitect, typeof(HammererArchitectBattleFieldControls)},
        {ClassId.PrancingMage, typeof(PrancingMageBattleFieldControls)},
    };

    public AbstractBattleFieldControls GetControls(ClassId controlsType)
    {
        if (!_classesTypes.ContainsKey(controlsType)) throw new ArgumentException($"Тип контроля {controlsType} не указан в создателе компонентов");
        
        var controlsClassType = _classesTypes[controlsType];
        return (AbstractBattleFieldControls) _container.InstantiateComponent(controlsClassType, gameObject);
    }
}

