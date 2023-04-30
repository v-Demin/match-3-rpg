using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public abstract class AbstractBattleFieldControls : MonoBehaviour
{
    [Inject] protected readonly BattleField BattleField;
    [Inject] protected readonly CrystalField CrystalField;
    protected BattleCharacter Character;
    
    public AbstractBattleFieldControls Init(BattleCharacter character)
    {
        $"Я заиничен {name} к персонажу {character.name}".Log(Color.black);
        BattleField.CellClicked += OnCellClicked;
        BattleField.CellDragStarted += OnCellDragStarted;
        BattleField.CellDragged += OnCellDragged;
        BattleField.CellDragEnded += OnCellDragEnded;
        BattleField.CellDroppedOn += OnCellDroppedOn;

        Character = character;
        
        return this;
    }

    protected abstract void OnCellClicked(PointerEventData data, Vector2Int index);
    protected abstract void OnCellDragStarted(PointerEventData data, Vector2Int index);
    protected abstract void OnCellDragged(PointerEventData data, Vector2Int index);
    protected abstract void OnCellDragEnded(PointerEventData data, Vector2Int index);
    protected abstract void OnCellDroppedOn(PointerEventData data, Vector2Int targetIndex, Vector2Int droppedIndex);
}
