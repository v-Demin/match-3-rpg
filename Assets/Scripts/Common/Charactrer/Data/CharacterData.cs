public class CharacterData
{
    public BioInfoData Bio { get; }
    public BaseClassData ClassData { get; }
    public BaseAttributesData BaseAttributes { get; }
    public BaseAttributesData MaxAttributes { get; }
    
    public CharacterData(BioInfoData bio, BaseClassData classData, BaseAttributesData baseAttributes, BaseAttributesData maxAttributes)
    {
        Bio = bio;
        ClassData = classData;
        BaseAttributes = baseAttributes;
        MaxAttributes = maxAttributes;
    }
}
