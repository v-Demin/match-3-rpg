using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseBattleFieldControls : AbstractBattleFieldControls
{
    protected override void OnCellClicked(PointerEventData data, Vector2Int index)
    {
        OnCellClickedInner(data, index, () =>
        {
            CrystalField.SwitchCrystals(SelectedIndex.Value, index);
        });
    }

    protected void OnCellClickedInner(PointerEventData data, Vector2Int index, Action onCorrectClick)
    {
        if (IsSelected(index))
        {
            SelectedIndex = null;
            return;
        }
        
        if (IsSelectable(index) && !IsSettable(index))
        {
            SelectedIndex = index;
            return;
        }

        if(IsNotInteractable(index)) return;

        if(SelectedIndex != null && !IsSettable(index)) return;
        
        onCorrectClick?.Invoke();
        SelectedIndex = null;
    }
}
