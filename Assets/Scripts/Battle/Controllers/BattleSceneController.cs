using DG.Tweening;
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
    [SerializeField] private RoundsController _roundsController;
    
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

        DOVirtual.DelayedCall(0.01f, () => _roundsController.StartGameplay());
    }

    private void InitAll()
    {
        _battleField.Init(Data.FieldData);
        DOVirtual.DelayedCall(0.01f, () => _crystalField.Init());
        
        _player.Init(Data.PlayerData);
        _enemy.Init(Data.EnemyData);
        
        _roundsController.Init(Data.RoundsData, _player.Controls, _enemy.Controls);
    }
}
