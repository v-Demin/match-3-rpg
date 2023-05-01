using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BattleSceneController : MonoBehaviour
{
    [Inject] private readonly BattleProvideService _provideService;
    
    [SerializeField] private BattleCharacter _player;
    [SerializeField] private BattleCharacter _enemy;
    [SerializeField] private BattleField _battleField;
    [SerializeField] private CrystalField _crystalField;
    
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
        _player.Init(Data.PlayerData);
        //_enemy.Init(Data.EnemyData);
        _battleField.Init(Data.FieldData);
        _crystalField.Init();
    }
}
