public class BattleData
{
    public CharacterData PlayerData { get; }
    public CharacterData EnemyData { get; }
    public BattleFieldData FieldData { get; }
    public RoundsData RoundsData { get; }
    public string BackgroundName { get; }

    public BattleData(CharacterData playerData, CharacterData enemyData, BattleFieldData fieldData, RoundsData roundsData, string backgroundName)
    {
        PlayerData = playerData;
        EnemyData = enemyData;
        FieldData = fieldData;
        RoundsData = roundsData;
        BackgroundName = backgroundName;
    }
}
