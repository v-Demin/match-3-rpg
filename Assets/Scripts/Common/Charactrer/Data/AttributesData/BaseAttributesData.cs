public class BaseAttributesData
{
    public float Health { get; }
    public float Mana { get; }
    public float Level { get; }

    public BaseAttributesData(float health, float mana, float level)
    {
        Health = health;
        Mana = mana;
        Level = level;
    }
}
