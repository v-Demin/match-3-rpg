using UnityEngine;

public class Crystal : MonoBehaviour
{
    [field: SerializeField] public CrystalType CrystalType { get; private set; }
    public Vector2Int Index { get; private set; }
    
    public Crystal Init(Vector2Int index)
    {
        Index = index;
        return this;
    }
    
    public void Show(ShowingType showingType)
    {
        
    }
    
        
    public enum ShowingType
    {
        Flash = 0,
        Fall = 1,
        Repainting = 2
    }
}
