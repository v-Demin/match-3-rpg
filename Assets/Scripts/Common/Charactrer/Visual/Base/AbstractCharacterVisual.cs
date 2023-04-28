using UnityEngine;

public abstract class AbstractCharacterVisual : MonoBehaviour
{
    [SerializeField] protected Animator Animator;

    public AbstractCharacterVisual Init(VisualData data)
    {
        AcceptVisual(data);
        return this;
    }

    protected abstract void AcceptVisual(VisualData data);
    
    public abstract void AttachTo(AbstractCharacter character);
}
