using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinMaxSliderParameter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _minValueField;
    [SerializeField] private TMP_InputField _maxValueField;
    [SerializeField] private TextMeshProUGUI _currentValueText;
    [SerializeField] private Slider _baseValueSlider;

    [SerializeField] private bool _isAvailableToChangeInput;

    public int MinValue => int.Parse(_minValueField.text);
    public int MaxValue => int.Parse(_maxValueField.text);
    public int BaseValue => Mathf.RoundToInt( MinValue + (MaxValue - MinValue) * _baseValueSlider.value);

    public void Start()
    {
        
        
        _minValueField.interactable = _isAvailableToChangeInput;
        _maxValueField.interactable = _isAvailableToChangeInput;

        UpdateParameters();
    }

    public void UpdateParameters()
    {
        _currentValueText.text = BaseValue.ToString();
    }
}
