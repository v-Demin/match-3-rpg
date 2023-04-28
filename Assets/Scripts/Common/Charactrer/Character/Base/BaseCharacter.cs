public abstract class BaseCharacter<T> : AbstractCharacter where T : BaseEventProvider
{
    public T EventProvider;

    protected virtual void Awake()
    {
        CreateEventProvider();
    }

    protected abstract void CreateEventProvider();
}
