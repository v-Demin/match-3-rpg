public abstract class BaseCharacter<T> : AbstractCharacter where T : AbstractEventProvider
{
    public T EventProvider { get; protected set; }

    protected virtual void Awake()
    {
        CreateEventProvider();
    }

    protected abstract void CreateEventProvider();
}
