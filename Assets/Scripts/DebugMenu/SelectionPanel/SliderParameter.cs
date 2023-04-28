using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderParameter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _maxValueField;
    [SerializeField] private TextMeshProUGUI _currentValueText;
    [SerializeField] private Slider _baseValueSlider;

    public int MaxValue => int.Parse(_maxValueField.text);
    public int BaseValue => Mathf.RoundToInt(MaxValue * _baseValueSlider.value);

    public void UpdateParameters()
    {
        _currentValueText.text = BaseValue.ToString();
    }
}
