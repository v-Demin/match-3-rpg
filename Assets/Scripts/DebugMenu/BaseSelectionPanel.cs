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
    [SerializeField] private TMP_InputField _healthInput;
    [SerializeField] private TMP_InputField _manaInput;
    [SerializeField] private TMP_InputField _levelInput;

    [Header("Settings")]
    [SerializeField] private List<ClassSelectionInfo> _availableClasses;

    private ClassId GetClassIdFromSelection => Enum.Parse<ClassId>(_classSelection.captionText.text);

    private void Start()
    {
        _classSelection.options = _availableClasses
                .DistinctBy(info => info)
                .Select(info => new TMP_Dropdown.OptionData(info.ClassId.ToString()))
                .ToList();
        
        SelectPanel();
    }

    public CharacterData GetCharacterData()
    {
        var bio = new BioInfoData(_nameInput.text);
        
        var classInfo = _availableClasses
                .FirstOrDefault(info => info.ClassId.Equals(GetClassIdFromSelection)).Panel.GetClassData;
        
        var attributes = new BaseAttributesData(
            int.Parse(_healthInput.text),
            int.Parse(_manaInput.text), 
            int.Parse(_levelInput.text));
        
        return new CharacterData(bio, classInfo, attributes);
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
