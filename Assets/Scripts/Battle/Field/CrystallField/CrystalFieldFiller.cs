using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CrystalFieldFiller : MonoBehaviour
{
    [Inject] private BattleField _battleField;
    [SerializeField] private Transform _contentRoot;

    [SerializeField] private List<CrystalInfo> _infos;

    private int X => _battleField.Data.FieldSize.x;
    private int Y => _battleField.Data.FieldSize.y;

    public Crystal[,] FillField()
    {
        var toReturn = new Crystal[_battleField.Data.FieldSize.x, _battleField.Data.FieldSize.y];
        
        for (var j = 0; j < Y; j++)
        {
            for (var i = 0; i < X; i++)
            {
                toReturn[i, j] = CreateCrystal(Crystal.ShowingType.Fall).Init(new Vector2Int(i, j));
                toReturn[i, j].transform.position = _battleField.Cells[i, j].transform.position;
            }
        }
        
        return toReturn;
    }

    public Crystal CreateCrystal(Crystal.ShowingType showingType)
    {
        return CreateCrystal(showingType, typeof(CrystalType).GetRandomValue<CrystalType>());
    }
    
    public Crystal CreateCrystal(Crystal.ShowingType showingType, CrystalType type)
    {
        return Instantiate<Crystal>(_infos.FirstOrDefault(info => info.Type.Equals(type)).Prefab, _contentRoot);
    }

    [System.Serializable]
    private class CrystalInfo
    {
        public CrystalType Type;
        public Crystal Prefab;
    }
}
