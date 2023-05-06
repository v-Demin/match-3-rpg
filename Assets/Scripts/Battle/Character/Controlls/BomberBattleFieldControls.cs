using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BomberBattleFieldControls : BaseBattleFieldControls
{
    
    #region NotUsed

    protected override void OnCellDragStarted(PointerEventData data, Vector2Int index)
    {
    }

    protected override void OnCellDragged(PointerEventData data, Vector2Int index)
    {
    }

    protected override void OnCellDragEnded(PointerEventData data, Vector2Int index)
    {
    }

    protected override void OnCellExited(PointerEventData data, Vector2Int index)
    {
    }

    protected override void OnCellDroppedOn(PointerEventData data, Vector2Int targetIndex, Vector2Int droppedIndex)
    {
    }
    
    #endregion
    
    #region Predicates
    
    protected override bool IsSelectable(Vector2Int index) => base.IsSelectable(index) && CrystalField.GetCrystal(index).CurrentConditionState ==
                                                              Crystal.ConditionState.Charged;

    protected override bool IsSettable(Vector2Int index) => SelectedIndex != null && 
                                                            ((Math.Abs(SelectedIndex.Value.x - index.x) <= 1) && 
                                                             (Math.Abs(SelectedIndex.Value.y - index.y) <= 1));
    
    #endregion
}
