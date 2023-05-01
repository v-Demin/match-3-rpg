using System;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private List<StateInfo> _stateInfos;

    private Vector2Int _index;
    
    public BattleFieldCell Init(Vector2Int index)
    {
        _index = index;
        name = $"Cell {index}";
        _textMesh.text = index.ToString();
        return this;
    }

    public void ChangeState(SelectionState selectionState)
    {
        _stateInfos.ForEach(info => info.StateRoot.SetActive(false));
        _stateInfos.FirstOrDefault(info => info.selectionState == selectionState).StateRoot.SetActive(true);
    }
    
    #region Pointers

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

    #endregion

    #region InnerClasses

    public enum SelectionState
    {
        Base = 0,
        Selected = 1,
        Interactable = 2,
        NotInteractable = 3,
        Settable = 4
    }

    [System.Serializable]
    private class StateInfo
    {
        public SelectionState selectionState;
        public GameObject StateRoot;
    }

    #endregion
}
