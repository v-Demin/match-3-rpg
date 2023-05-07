using TMPro;
using UnityEngine;

public class RoundSelectionPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public CharacterType CharacterType { get; private set; }

    public void SelectCharacterType(bool type)
    {
        CharacterType = type ? CharacterType.Player : CharacterType.Enemy;
        _text.text = CharacterType.ToString();
    }
}
