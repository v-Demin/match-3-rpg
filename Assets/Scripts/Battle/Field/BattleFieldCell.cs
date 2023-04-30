using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleFieldCell : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public event Action<PointerEventData, Vector2Int> Clicked;
    public event Action<PointerEventData, Vector2Int> DragStarted;
    public event Action<PointerEventData, Vector2Int> Dragged;
    public event Action<PointerEventData, Vector2Int> DragEnded;
    public event Action<PointerEventData, Vector2Int, Vector2Int> DroppedOn;
    
    private Vector2Int _index;

    [SerializeField] private TextMeshProUGUI _textMesh;

    public BattleFieldCell Init(Vector2Int index)
    {
        _index = index;
        name = $"Cell {index}";
        _textMesh.text = index.ToString();
        return this;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(eventData, _index);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        DragStarted?.Invoke(eventData, _index);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Dragged?.Invoke(eventData, _index);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragEnded?.Invoke(eventData, _index);
    }

    public void OnDrop(PointerEventData eventData)
    {
        DroppedOn?.Invoke(eventData, _index, eventData.pointerDrag.GetComponent<BattleFieldCell>()._index);
    }
}
