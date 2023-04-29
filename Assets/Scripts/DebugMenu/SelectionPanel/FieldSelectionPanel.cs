using UnityEngine;

public class FieldSelectionPanel : MonoBehaviour
{
    [SerializeField] private MinMaxSliderParameter _xSlider;
    [SerializeField] private MinMaxSliderParameter _ySlider;

    public BattleFieldData GetFieldData()
    {
        var fieldSize = new Vector2Int(_xSlider.BaseValue, _ySlider.BaseValue);

        return new BattleFieldData(fieldSize);
    }
}
