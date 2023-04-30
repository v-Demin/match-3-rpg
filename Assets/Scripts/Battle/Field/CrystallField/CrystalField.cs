using DG.Tweening;
using UnityEngine;
using Zenject;

public class CrystalField : MonoBehaviour
{
    [Inject] private readonly BattleField _battleField;
    [SerializeField] private CrystalFieldFiller _filler;

    public Crystal[,] Cells { get; private set; }

    public void Init()
    {
        DOVirtual.DelayedCall(0.01f, () => Cells = _filler.FillField());
    }

    public void MakeCrystalFollowMouse(Vector2Int index)
    {
        Cells[index.x, index.y].transform.SetAsLastSibling();
        Cells[index.x, index.y].transform.position = new Vector3(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
            -1f);
    }

    public void SwitchCrystals(Vector2Int index, Vector2Int index2)
    {
        Cells[index.x, index.y].transform.SetAsLastSibling();
        Cells[index2.x, index2.y].transform.SetAsLastSibling();
        Cells[index.x, index.y].transform.DOMove(_battleField.Cells[index2.x, index2.y].transform.position, 1f).SetEase(Ease.InOutQuint);
        Cells[index2.x, index2.y].transform.DOMove(_battleField.Cells[index.x, index.y].transform.position, 1f).SetEase(Ease.InOutQuint);

        var c = Cells[index.x, index.y];
        var c2 = Cells[index2.x, index2.y];
        Cells[index2.x, index2.y] = c;
        Cells[index.x, index.y] = c2;
    }

    public void MoveBack(Vector2Int index)
    {
        Cells[index.x, index.y].transform.DOMove(_battleField.Cells[index.x, index.y].transform.position, 1f);
    }
}
