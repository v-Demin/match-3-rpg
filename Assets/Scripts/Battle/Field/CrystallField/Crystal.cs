using UnityEngine;

public class Crystal : MonoBehaviour
{
    [field: SerializeField] public CrystalType CrystalType { get; private set; }
    [field: SerializeField] public ConditionState CurrentConditionState { get; private set; } = ConditionState.Base;
    public Vector2Int Index { get; private set; }
    
    public Crystal Init(Vector2Int index)
    {
        Index = index;
        return this;
    }
    
    public void Show(ShowingType showingType)
    {
        
    }

    public void ChangeState(ConditionState state)
    {
        CurrentConditionState = state;
    }
        
    public enum ShowingType
    {
        Flash = 0,
        Fall = 1,
        Repainting = 2
    }
    
    public enum ConditionState
    {
        Base = 0,
        Cursed = 1,
        Charged = 2
    }
}
