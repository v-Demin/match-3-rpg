public abstract class BaseCharacter<T> : AbstractCharacter where T : AbstractEventProvider
{
    public T EventProvider;

    protected virtual void Awake()
    {
        CreateEventProvider();
    }

    protected abstract void CreateEventProvider();
}
