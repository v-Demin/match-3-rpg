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
    [SerializeField] private List<ClassId> _availableClasses;

    private void Start()
    {
        _classSelection.options = _availableClasses
                .DistinctBy(classId => classId)
                .Select(classId => new TMP_Dropdown.OptionData(classId.ToString()))
                .ToList();
    }

    public CharacterData GetCharacterData()
    {
        var bio = new BioInfoData(_nameInput.text);
        var classInfo = new BaseClassData(Enum.Parse<ClassId>(_classSelection.captionText.text));
        var attributes = new BaseAttributesData(
            int.Parse(_healthInput.text),
            int.Parse(_manaInput.text), 
            int.Parse(_levelInput.text));
        
        return new CharacterData(bio, classInfo, attributes);
    }
}
