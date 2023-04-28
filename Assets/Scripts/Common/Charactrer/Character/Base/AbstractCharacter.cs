using UnityEngine;

public abstract class AbstractCharacter : MonoBehaviour
{
    [SerializeField] private AbstractCharacterVisual _visual;
    
    protected CharacterData Data { get; private set; }
    
    public void Init(CharacterData data)
    {
        Data = data;
        AttachEverything();
    }

    protected virtual void AttachEverything()
    {
        AttachBio(Data.Bio);
        AttachClass(Data.ClassData);
        AttachMaxAttributes(Data.MaxAttributes);
        AttachBaseAttributes(Data.BaseAttributes);
        AttachVisual(Data.VisualData);
    }

    protected abstract void AttachBio(BioInfoData bio);
    protected abstract void AttachClass(BaseClassData classData);
    protected abstract void AttachMaxAttributes(BaseAttributesData baseAttributes);
    protected abstract void AttachBaseAttributes(BaseAttributesData maxAttributes);
    protected virtual void AttachVisual(VisualData visualData)
    {
        _visual.Init(visualData).AttachTo(this);
    }
}
