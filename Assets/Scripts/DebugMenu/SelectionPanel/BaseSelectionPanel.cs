using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BaseSelectionPanel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private TMP_Dropdown _classSelection;
    [SerializeField] private SliderParameter _healthInput;
    [SerializeField] private SliderParameter _manaInput;
    [SerializeField] private SliderParameter _levelInput;

    [Header("Settings")]
    [SerializeField] private List<ClassSelectionInfo> _availableClasses;

    private ClassId GetClassIdFromSelection => Enum.Parse<ClassId>(_classSelection.captionText.text);

    private void Start()
    {
        _classSelection.options = _availableClasses
                .Select(info => new TMP_Dropdown.OptionData(info.ClassId.ToString()))
                .ToList();
        
        SelectPanel();
    }

    public CharacterData GetCharacterData()
    {
        var bio = new BioInfoData(_nameInput.text);
        
        var classInfo = _availableClasses
                .FirstOrDefault(info => info.ClassId.Equals(GetClassIdFromSelection)).Panel.GetClassData;

        var baseAttributes = new BaseAttributesData(_healthInput.MaxValue, _manaInput.MaxValue);
        var maxAttributes = new BaseAttributesData(_healthInput.BaseValue, _manaInput.BaseValue);
        
        return new CharacterData(bio, classInfo, baseAttributes, maxAttributes);
    }

    public void SelectPanel()
    {
        _availableClasses.ForEach(info => info.Panel.gameObject.SetActive(false));
        _availableClasses[_classSelection.value].Panel.gameObject.SetActive(true);
    }
    
    [System.Serializable]
    private class ClassSelectionInfo
    {
        public ClassId ClassId;
        public AbstractClassDataPanel Panel;
    }
}
