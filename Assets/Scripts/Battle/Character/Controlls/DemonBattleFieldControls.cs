using UnityEngine;
using UnityEngine.EventSystems;

public class DemonBattleFieldControls : AbstractBattleFieldControls
{
    private Vector2Int? _lastClickedIndex;
    
    protected override void OnCellClicked(PointerEventData data, Vector2Int index)
    {
        if (_lastClickedIndex == null)
        {
            _lastClickedIndex = index;
            return;
        }

        if (_lastClickedIndex == index)
        {
            _lastClickedIndex = null;
            return;
        }

        CrystalField.SwitchCrystals(_lastClickedIndex.Value, index);
        _lastClickedIndex = null;
    }


    protected override void OnCellDragStarted(PointerEventData data, Vector2Int index)
    {
    }

    protected override void OnCellDragged(PointerEventData data, Vector2Int index)
    {
        CrystalField.MakeCrystalFollowMouse(index);
    }

    protected override void OnCellDragEnded(PointerEventData data, Vector2Int index)
    {
        CrystalField.MoveBack(index);
    }

    protected override void OnCellDroppedOn(PointerEventData data, Vector2Int targetIndex, Vector2Int droppedIndex)
    {
        CrystalField.SwitchCrystals(targetIndex, droppedIndex);
    }
}
