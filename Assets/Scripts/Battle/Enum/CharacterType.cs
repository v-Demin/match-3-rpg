public enum CharacterType
{
    Player = 0,
    Enemy = 1
}

public static class CharacterTypeExtensions
{
    public static CharacterType Switch(this CharacterType enumValue)
    {
        return enumValue == CharacterType.Player ? CharacterType.Enemy : CharacterType.Player;
    }
}
