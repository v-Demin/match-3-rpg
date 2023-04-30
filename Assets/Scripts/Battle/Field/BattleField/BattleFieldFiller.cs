using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleFieldFiller : MonoBehaviour
{
    [SerializeField] private BattleFieldCell _prefab;
    [SerializeField] private GridLayoutGroup _grid;
    [SerializeField] private Transform _contentRoot;
    
    public BattleFieldCell[,] FillGrid(int x, int y)
    {
        _grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _grid.constraintCount = x;
        
        var toReturn = new BattleFieldCell[x, y];
        
        for (var j = 0; j < y; j++)
        {
            for (var i = 0; i < x; i++)
            {
                toReturn[i, j] = CreateCell(i, j);
            }
        }

        return toReturn;
    }
    
    private BattleFieldCell CreateCell(int x, int y)
    {
        var cell = Instantiate(_prefab, _contentRoot)
            .Init(new Vector2Int(x, y));
        cell.gameObject.SetActive(true);

        return cell;
    }
}
