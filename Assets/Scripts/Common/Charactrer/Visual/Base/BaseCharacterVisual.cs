public abstract class BaseCharacterVisual<T> : AbstractCharacterVisual where T : AbstractCharacter
{
    public override void AttachTo(AbstractCharacter character)
    {
        AttachToInner(character as T);
    }

    protected abstract void AttachToInner(T character);
}
