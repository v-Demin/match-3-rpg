public class CharacterData
{
    public BioInfoData Bio { get; }
    public BaseClassData ClassData { get; }
    public BaseAttributesData BaseAttributes { get; }
    
    public CharacterData(BioInfoData bio, BaseClassData classData, BaseAttributesData baseAttributes)
    {
        Bio = bio;
        ClassData = classData;
        BaseAttributes = baseAttributes;
    }
}
