public class RoundsData
{
    public int PlayerMovesInRoundMax { get;}
    public int EnemyMovesInRoundMax { get;}
    public CharacterType FirstMoveSide { get;}
    
    public RoundsData(CharacterData playerData, CharacterData enemyData, CharacterType firstMoveSide)
    {
        PlayerMovesInRoundMax = playerData.MovesInRound;
        EnemyMovesInRoundMax = enemyData.MovesInRound;
        FirstMoveSide = firstMoveSide;
    }
}
