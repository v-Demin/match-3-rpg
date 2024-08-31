using System;
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
        var width = _battleField.Data.FieldSize.x;
        var height = _battleField.Data.FieldSize.y;
        var typeField = GenerateTypeField();
        var toReturn = new Crystal[_battleField.Data.FieldSize.x, _battleField.Data.FieldSize.y];
        
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                toReturn[x, y] = CreateCrystal(Crystal.ShowingType.Fall, typeField[x, y]).Init(new Vector2Int(x, y));
                toReturn[x, y].transform.position = _battleField.Cells[x, y].transform.position;
            }
        }
        
        return toReturn;
    }

    //[Todo]: Рефакторинг за ChatGPT
    private CrystalType[,] GenerateTypeField()
    {
        var width = _battleField.Data.FieldSize.x;
        var height = _battleField.Data.FieldSize.y;
        var toReturn = new CrystalType[width, height];

        var crystalTypes = Enum.GetValues(typeof(CrystalType));
        var random = new System.Random();

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                CrystalType newType;
                do
                {
                    newType = (CrystalType)crystalTypes.GetValue(random.Next(crystalTypes.Length));
                }
                while ((x >= 2 && newType == toReturn[x - 1, y] && newType == toReturn[x - 2, y]) ||
                       (y >= 2 && newType == toReturn[x, y - 1] && newType == toReturn[x, y - 2]));

                toReturn[x, y] = newType;
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
        return Instantiate(_infos.FirstOrDefault(info => info.Type.Equals(type)).Prefab, _contentRoot);
    }

    [System.Serializable]
    private class CrystalInfo
    {
        public CrystalType Type;
        public Crystal Prefab;
    }
}
