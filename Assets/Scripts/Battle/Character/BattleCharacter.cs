using Zenject;

public class BattleCharacter : BaseCharacter<BattleCharacterEventProvider>
{
    [Inject] private readonly BattleFieldModelControllCreator _creator;

    public AbstractBattleFieldControls Controls;
    
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
        Controls = _creator.GetControls(classData.ClassId)
            .Init(this);
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
