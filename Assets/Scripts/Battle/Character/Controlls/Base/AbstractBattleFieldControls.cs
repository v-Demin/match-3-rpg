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
        BattleField.CellClicked += OnCellClicked;
        BattleField.CellDragStarted += OnCellDragStarted;
        BattleField.CellDragged += OnCellDragged;
        BattleField.CellDragEnded += OnCellDragEnded;
        BattleField.CellExit += OnCellExited;
        BattleField.CellDroppedOn += OnCellDroppedOn;

        Character = character;

        return this;
    }

    protected abstract void OnCellClicked(PointerEventData data, Vector2Int index);
    protected abstract void OnCellDragStarted(PointerEventData data, Vector2Int index);
    protected abstract void OnCellDragged(PointerEventData data, Vector2Int index);
    protected abstract void OnCellDragEnded(PointerEventData data, Vector2Int index);
    protected abstract void OnCellExited(PointerEventData data, Vector2Int index);
    protected abstract void OnCellDroppedOn(PointerEventData data, Vector2Int targetIndex, Vector2Int droppedIndex);

    protected virtual bool IsSelected(Vector2Int index) => SelectedIndex != null && index.Equals(SelectedIndex.Value);
    protected virtual bool IsValidMove(Vector2Int index) => index.x >= 0 && index.x < BattleField.Cells.GetLength(0) &&
                                                            index.y >= 0 && index.y < BattleField.Cells.GetLength(1);    
    protected virtual bool IsSelectable(Vector2Int index) => IsValidMove(index);
    protected abstract bool IsSettable(Vector2Int index);
    
    protected virtual bool IsNotInteractable(Vector2Int index) => !IsSettable(index) && !IsSelected(index) && !IsSelectable(index) || CrystalField.Cells[index.x, index.y].CurrentConditionState == Crystal.ConditionState.Cursed;


    protected virtual void RefreshField()
    {
        MarkAllCellsAs(IsSelectable, BattleFieldCell.SelectionState.Selectable);
        MarkAllCellsAs(IsSettable, BattleFieldCell.SelectionState.Settable);
        MarkAllCellsAs(IsSelected, BattleFieldCell.SelectionState.Selected);
        MarkAllCellsAs(IsNotInteractable, BattleFieldCell.SelectionState.NotInteractable);
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
