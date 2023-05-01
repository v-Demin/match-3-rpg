using UnityEngine;
using UnityEngine.EventSystems;

public class DemonBattleFieldControls : AbstractBattleFieldControls
{
    #region CellControls

    protected override void OnCellClicked(PointerEventData data, Vector2Int index)
    {
        if (IsSelected(index))
        {
            SelectedIndex = null;
            return;
        }
        
        if(IsNotInteractable(index)) return;
        if(SelectedIndex != null && !IsSettable(index)) return;
        
        if (SelectedIndex == null)
        {
            SelectedIndex = index;
            return;
        }

        CrystalField.SwitchCrystals(SelectedIndex.Value, index);
        CrystalField.GetCrystal(SelectedIndex.Value).ChangeState(Crystal.ConditionState.Cursed);
        CrystalField.GetCrystal(index).ChangeState(Crystal.ConditionState.Cursed);
        SelectedIndex = null;
    }


    protected override void OnCellDragStarted(PointerEventData data, Vector2Int index)
    {
        if(IsNotInteractable(index)) return;
        SelectedIndex = index;
    }

    protected override void OnCellDragged(PointerEventData data, Vector2Int index)
    {
        if(IsNotInteractable(index)) return;
        CrystalField.MakeCrystalFollowMouse(index);
    }

    protected override void OnCellDragEnded(PointerEventData data, Vector2Int index)
    {
        SelectedIndex = null;
        CrystalField.MoveBack(index);
    }

    protected override void OnCellDroppedOn(PointerEventData data, Vector2Int targetIndex, Vector2Int droppedIndex)
    {
        if(IsNotInteractable(droppedIndex) || !IsSettable(targetIndex)) return;
        CrystalField.SwitchCrystals(targetIndex, droppedIndex);
        CrystalField.GetCrystal(targetIndex).ChangeState(Crystal.ConditionState.Cursed);
        CrystalField.GetCrystal(droppedIndex).ChangeState(Crystal.ConditionState.Cursed);
        SelectedIndex = null;
    }
    
    #endregion

    #region NotUsed
    
    protected override void OnCellExited(PointerEventData data, Vector2Int index)
    {
    }
    
    #endregion

    #region Predicates

    protected override bool IsSettable(Vector2Int index) => SelectedIndex != null &&
                                                            CrystalField.GetCrystal(index)
                                                                .CurrentConditionState != Crystal.ConditionState.Cursed;

    #endregion
}
