using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public abstract class AbstractBattleFieldControls : MonoBehaviour
{
    [Inject] protected readonly BattleField BattleField;
    [Inject] protected readonly CrystalField CrystalField;
    protected BattleCharacter Character;

    private Vector2Int? _selectedIndex;
    protected Vector2Int? SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            RefreshField();
        }
    }

    public AbstractBattleFieldControls Init(BattleCharacter character)
    {
        $"Я заиничен {GetType()} к персонажу {character.name}".Log(Color.black);
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

    protected virtual bool IsSelected(Vector2Int index) => SelectedIndex != null && index.Equals(SelectedIndex.Value);
    protected virtual bool IsBase(Vector2Int index) => true;
    protected virtual bool IsInteractable(Vector2Int index) => CrystalField.Cells[index.x, index.y].CurrentConditionState != Crystal.ConditionState.Cursed;
    protected virtual bool IsNotInteractable(Vector2Int index) => IsInteractable(index) == false;
    protected abstract bool IsSettable(Vector2Int index);

    protected virtual void RefreshField()
    {
        MarkAllCellsAs(IsBase, BattleFieldCell.SelectionState.Base);
        MarkAllCellsAs(IsInteractable, BattleFieldCell.SelectionState.Interactable);
        MarkAllCellsAs(IsNotInteractable, BattleFieldCell.SelectionState.NotInteractable);
        MarkAllCellsAs(IsSettable, BattleFieldCell.SelectionState.Settable);
        MarkAllCellsAs(IsSelected, BattleFieldCell.SelectionState.Selected);
    }


    protected virtual void MarkAllCellsAs(Predicate<Vector2Int> condition, BattleFieldCell.SelectionState selectionState)
    {
        for (var j = 0; j < BattleField.Cells.GetLength(1); j++)
        {
            for (var i = 0; i < BattleField.Cells.GetLength(0); i++)
            {
                if (condition(new Vector2Int(i, j)))
                {
                    BattleField.Cells[i, j].ChangeState(selectionState);
                }
            }
        }
    }
}
