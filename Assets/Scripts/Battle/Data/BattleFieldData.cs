using UnityEngine;

public class BattleFieldData
{
    private const int MIN_X_SIZE = 4;
    private const int MAX_X_SIZE = 7;
    
    private const int MIN_Y_SIZE = 4;
    private const int MAX_Y_SIZE = 7;
    
    public Vector2Int FieldSize { get; }

    public BattleFieldData(Vector2Int fieldSize)
    {
        FieldSize = new Vector2Int(
            Mathf.Clamp(fieldSize.x, MIN_X_SIZE, MAX_X_SIZE),
            Mathf.Clamp(fieldSize.y, MIN_Y_SIZE, MAX_Y_SIZE)
        );
    }
}
