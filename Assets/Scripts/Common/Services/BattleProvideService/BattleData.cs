public class BattleData
{
    public CharacterData PlayerData { get; }
    public CharacterData EnemyData { get; }
    public string BackgroundName { get; }

    public BattleData(CharacterData playerData, CharacterData enemyData, string backgroundName)
    {
        PlayerData = playerData;
        EnemyData = enemyData;
        BackgroundName = backgroundName;
    }
}
