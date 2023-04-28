public abstract class BaseEventProvider<T> : AbstractEventProvider where T : AbstractCharacter
{
    public override void AttachTo(AbstractCharacter character)
    {
        AttachToInner(character as T);
    }

    protected abstract void AttachToInner(T character);
}
