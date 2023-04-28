public class BattleCharacter : BaseCharacter<BattleCharacterEventProvider>
{
    protected override void CreateEventProvider()
    {
        EventProvider = new BattleCharacterEventProvider();
    }

    protected override void AttachBio(BioInfoData bio)
    {
        throw new System.NotImplementedException();
    }

    protected override void AttachClass(BaseClassData classData)
    {
        throw new System.NotImplementedException();
    }

    protected override void AttachMaxAttributes(BaseAttributesData baseAttributes)
    {
        throw new System.NotImplementedException();
    }

    protected override void AttachBaseAttributes(BaseAttributesData maxAttributes)
    {
        throw new System.NotImplementedException();
    }
}
