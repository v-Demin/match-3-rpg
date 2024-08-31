using UnityEngine;

public class RoundsController : MonoBehaviour
{
    private RoundsData _data;
    private (AbstractBattleFieldControls controls, int maxTurns) _playerSide;
    private (AbstractBattleFieldControls controls, int maxTurns) _enemySide;
    private CharacterType _currentSide;
    private (AbstractBattleFieldControls controls, int maxTurns) CurrentSide => _currentSide == CharacterType.Player ? _playerSide : _enemySide;

    private int _movesLeft;
    
    public void Init(RoundsData data, AbstractBattleFieldControls player, AbstractBattleFieldControls enemy)
    {
        _data = data;
        _playerSide.controls = player;
        _enemySide.controls = enemy;
        _playerSide.maxTurns = _data.PlayerMovesInRoundMax;
        _enemySide.maxTurns = _data.EnemyMovesInRoundMax;

        _currentSide = _data.FirstMoveSide;
    }

    public void StartGameplay()
    {
        EnableCharacterSide();
        _movesLeft = CurrentSide.maxTurns;
    }

    private void ActionSubmitted()
    {
        _movesLeft--;
        _movesLeft.Log(Color.green);
        if (_movesLeft <= 0)
        {
            StartNewRound();
        }
    }

    private void StartNewRound()
    {
        Switch();
        _movesLeft = CurrentSide.maxTurns;
    }
    
    private void Switch()
    {
        DisableCharacterSide();
        _currentSide = _currentSide.Switch();
        EnableCharacterSide();
    }
    
    private void EnableCharacterSide()
    {
        CurrentSide.controls.IsActive = true;
        CurrentSide.controls.OnActionSubmitted += ActionSubmitted;
    }

    private void DisableCharacterSide()
    {
        CurrentSide.controls.IsActive = false;
        CurrentSide.controls.OnActionSubmitted -= ActionSubmitted;
    }
}
