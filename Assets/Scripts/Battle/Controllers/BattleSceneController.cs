using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BattleSceneController : MonoBehaviour
{
    [Inject] private readonly BattleProvideService _provideService;
    
    [SerializeField] private BattleCharacter _player;
    [SerializeField] private BattleCharacter _enemy;
    [SerializeField] private BattleField _field;
    
    public BattleData Data { get; private set; }

    private void Start()
    {
        if (_provideService.Data == null)
        {
            SceneManager.LoadScene("DebugModeScreen");
            return;
        }
        
        Data = _provideService.Data;
        InitAll();
    }

    private void InitAll()
    {
        //_player.Init(Data.PlayerData);
        //_enemy.Init(Data.EnemyData);
        _field.Init(Data.FieldData);
    }
}
