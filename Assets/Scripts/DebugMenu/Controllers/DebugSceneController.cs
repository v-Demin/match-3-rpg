using UnityEngine;
using Zenject;

public class DebugSceneController : MonoBehaviour
{
    [Inject] private BattleProvideService _provideService;

    [SerializeField] private BaseSelectionPanel _playerSelectionPanel;
    [SerializeField] private BaseSelectionPanel _enemySelectionPanel;

    public void StartScene()
    {
        var player = _playerSelectionPanel.GetCharacterData();
        var enemy = _enemySelectionPanel.GetCharacterData();
        var backgroundName = "";
        
        _provideService.StartBattle(new BattleData(player, enemy, backgroundName));
    }
}