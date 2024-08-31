using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class CrystalField : MonoBehaviour
{
    private const float SWITCHING_CRYSTALS_DURATION = 0.5f;
    [Inject] private readonly BattleField _battleField;
    [SerializeField] private CrystalFieldFiller _filler;

    public Crystal[,] Cells { get; private set; }
    
    public Crystal GetCrystal(Vector2Int index)
    {
        return Cells[index.x, index.y];
    }

    public void Init()
    {
        Cells = _filler.FillField();
    }

    public void MakeCrystalFollowMouse(Vector2Int index)
    {
        Cells[index.x, index.y].transform.SetAsLastSibling();
        Cells[index.x, index.y].transform.position = new Vector3(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
            -1f);
    }

    public void SwitchCrystals(Vector2Int index, Vector2Int index2, Action OnComplete = null)
    {
        Cells[index.x, index.y].transform.SetAsLastSibling();
        Cells[index2.x, index2.y].transform.SetAsLastSibling();
        Cells[index.x, index.y].transform.DOMove(_battleField.Cells[index2.x, index2.y].transform.position, SWITCHING_CRYSTALS_DURATION).SetEase(Ease.InOutQuint);
        Cells[index2.x, index2.y].transform.DOMove(_battleField.Cells[index.x, index.y].transform.position, SWITCHING_CRYSTALS_DURATION).SetEase(Ease.InOutQuint);

        var c = Cells[index.x, index.y];
        var c2 = Cells[index2.x, index2.y];
        c.Init(index2);
        c2.Init(index);
        Cells[index2.x, index2.y] = c;
        Cells[index.x, index.y] = c2;

        DOVirtual.DelayedCall(SWITCHING_CRYSTALS_DURATION, () =>
        {
            OnComplete?.Invoke();
        });
    }

    public void MoveBack(Vector2Int index)
    {
        Cells[index.x, index.y].transform.DOMove(_battleField.Cells[index.x, index.y].transform.position, 1f);
    }

    //[Todo]: Рефакторинг за ChatGPT
    private List<Crystal> GetMatchedCrystals()
    {
        int width = Cells.GetLength(0);
        int height = Cells.GetLength(1);

        var matchedCrystals = new List<Crystal>();

        // Проверка горизонтальных последовательностей
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width - 2; x++)
            {
                Crystal current = Cells[x, y];
                if (current.CrystalType == Cells[x + 1, y].CrystalType &&
                    current.CrystalType == Cells[x + 2, y].CrystalType)
                {
                    matchedCrystals.Add(current);
                    matchedCrystals.Add(Cells[x + 1, y]);
                    matchedCrystals.Add(Cells[x + 2, y]);

                    // Продолжаем добавлять кристаллы, если последовательность длиннее трех
                    int extendX = x + 3;
                    while (extendX < width && Cells[extendX, y].CrystalType == current.CrystalType)
                    {
                        matchedCrystals.Add(Cells[extendX, y]);
                        extendX++;
                    }

                    x = extendX - 1; // Переход к следующей позиции после найденной последовательности
                }
            }
        }

        // Проверка вертикальных последовательностей
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height - 2; y++)
            {
                Crystal current = Cells[x, y];
                if (current.CrystalType == Cells[x, y + 1].CrystalType &&
                    current.CrystalType == Cells[x, y + 2].CrystalType)
                {
                    matchedCrystals.Add(current);
                    matchedCrystals.Add(Cells[x, y + 1]);
                    matchedCrystals.Add(Cells[x, y + 2]);

                    // Продолжаем добавлять кристаллы, если последовательность длиннее трех
                    int extendY = y + 3;
                    while (extendY < height && Cells[x, extendY].CrystalType == current.CrystalType)
                    {
                        matchedCrystals.Add(Cells[x, extendY]);
                        extendY++;
                    }

                    y = extendY - 1; // Переход к следующей позиции после найденной последовательности
                }
            }
        }

        // Удаляем дубликаты кристаллов
        matchedCrystals = matchedCrystals.Distinct().ToList();

        return matchedCrystals;
    }
}
