public abstract class BaseClassData
{
    public ClassId ClassId { get; }

    protected BaseClassData(ClassId classId)
    {
        ClassId = classId;
    }
}
