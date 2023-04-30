using DG.Tweening;
using UnityEngine;

public class CrystalField : MonoBehaviour
{
    [SerializeField] private CrystalFieldFiller _filler;

    private Crystal[,] _crystals;

    public void Init()
    {
        DOVirtual.DelayedCall(0.01f, () => _crystals = _filler.FillField());
    }

    public void MakeCrystalFollowMouse(Vector2Int index)
    {
        
    }

    public void SwitchCrystals(Vector2Int index, Vector2Int index2)
    {
        
    }
}
