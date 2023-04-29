public class BattleData
{
    public CharacterData PlayerData { get; }
    public CharacterData EnemyData { get; }
    public BattleFieldData FieldData { get; }
    public string BackgroundName { get; }

    public BattleData(CharacterData playerData, CharacterData enemyData, BattleFieldData fieldData,  string backgroundName)
    {
        PlayerData = playerData;
        EnemyData = enemyData;
        FieldData = fieldData;
        BackgroundName = backgroundName;
    }
}
