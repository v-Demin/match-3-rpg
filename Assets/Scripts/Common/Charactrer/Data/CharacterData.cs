public class CharacterData
{
    public BioInfoData Bio;
    public BaseClassData ClassData;
    public BaseAttributesData BaseAttributes;
    
    public CharacterData(BioInfoData bio, BaseClassData classData, BaseAttributesData baseAttributes)
    {
        Bio = bio;
        ClassData = classData;
        BaseAttributes = baseAttributes;
    }
}
