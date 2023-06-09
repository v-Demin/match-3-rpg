using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleField : MonoBehaviour
{
    public event Action<PointerEventData, Vector2Int> CellClicked;
    public event Action<PointerEventData, Vector2Int> CellDragStarted;
    public event Action<PointerEventData, Vector2Int> CellDragged;
    public event Action<PointerEventData, Vector2Int> CellDragEnded;
    public event Action<PointerEventData, Vector2Int> CellExit;
    public event Action<PointerEventData, Vector2Int, Vector2Int> CellDroppedOn;

    [SerializeField] private BattleFieldFiller _filler;
    
    public BattleFieldCell[,] Cells { get; private set; }
    public BattleFieldData Data { get; private set; }
    
    public BattleFieldCell GetCell(Vector2Int index)
    {
        return Cells[index.x, index.y];
    }
    
    public void Init(BattleFieldData fieldData)
    {
        Data = fieldData;
        Cells = _filler.FillGrid(Data.FieldSize.x, Data.FieldSize.y);

        foreach (var cell in Cells)
        {
            cell.Clicked += (data, i) => CellClicked?.Invoke(data, i);
            cell.DragStarted += (data, i) => CellDragStarted?.Invoke(data, i);
            cell.Dragged += (data, i) => CellDragged?.Invoke(data, i);
            cell.DragEnded += (data, i) => CellDragEnded?.Invoke(data, i);
            cell.Exited += (data, i) => CellExit?.Invoke(data, i);
            cell.DroppedOn += (data, i, iDropped) => CellDroppedOn?.Invoke(data, i, iDropped);
        }
    }
}
