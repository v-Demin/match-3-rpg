using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class WarriorBattleFieldControls : AbstractBattleFieldControls
{
    private const float SENSITIVITY = 1f;
 
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
        SelectedIndex = null;
    }

    protected override void OnCellDragStarted(PointerEventData data, Vector2Int index)
    {
        if(IsNotInteractable(index)) return;
        SelectedIndex = index;
    }

    protected override void OnCellDragged(PointerEventData data, Vector2Int index)
    {
        if(SelectedIndex == null) return;
        var cell = (Vector2)BattleField.GetCell(index).transform.position;
        var drag = (Vector2)Camera.main.ScreenToWorldPoint(data.position);

        if (!((cell - drag).magnitude > SENSITIVITY)) return;

        var endIndex = index + new Vector2Int(
            (Vector3ShiftUtil.CheckIsRightShifted(cell, drag) ? 1 : 0) +
            (Vector3ShiftUtil.CheckIsLeftShifted(cell, drag) ? -1 : 0),
            (Vector3ShiftUtil.CheckIsUpShifted(cell, drag) ? 1 : 0) +
            (Vector3ShiftUtil.CheckIsDownShifted(cell, drag) ? -1 : 0));

        if (!IsSettable(endIndex)) return;
        
        SelectedIndex = null;

        CrystalField.SwitchCrystals(index, endIndex);

    }

    protected override void OnCellDragEnded(PointerEventData data, Vector2Int index)
    {
        SelectedIndex = null;
    }

    protected override void OnCellDroppedOn(PointerEventData data, Vector2Int targetIndex, Vector2Int droppedIndex)
    {
        if(IsNotInteractable(droppedIndex) || IsNotInteractable(targetIndex) || !IsSettable(targetIndex)) return;
        CrystalField.SwitchCrystals(targetIndex, droppedIndex);
        SelectedIndex = null;
    }
    
    #endregion

    #region NotUsed

    protected override void OnCellExited(PointerEventData data, Vector2Int index)
    {
    }

    #endregion

    #region Predicates

    protected override bool IsSettable(Vector2Int index) => IsInteractable(index) &&
                                                            SelectedIndex != null &&
                                                            ((Math.Abs(SelectedIndex.Value.x - index.x) == 1) &&
                                                             (Math.Abs(SelectedIndex.Value.y - index.y) == 0) ||
                                                             (Math.Abs(SelectedIndex.Value.x - index.x) == 0) &&
                                                             (Math.Abs(SelectedIndex.Value.y - index.y) == 1));
    #endregion
}
