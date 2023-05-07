using UnityEngine;
using Zenject;

public class DebugSceneController : MonoBehaviour
{
    [Inject] private readonly BattleProvideService _provideService;

    [SerializeField] private BaseSelectionPanel _playerSelectionPanel;
    [SerializeField] private BaseSelectionPanel _enemySelectionPanel;
    [SerializeField] private FieldSelectionPanel _fieldSelectionPanel;
    [SerializeField] private RoundSelectionPanel _roundSelectionPanel;

    public void StartScene()
    {
        var player = _playerSelectionPanel.GetCharacterData();
        var enemy = _enemySelectionPanel.GetCharacterData();
        var field = _fieldSelectionPanel.GetFieldData();
        var round = new RoundsData(player, enemy, _roundSelectionPanel.CharacterType);
        var backgroundName = "";
        
        _provideService.StartBattle(new BattleData(player, enemy, field, round, backgroundName));
    }
}