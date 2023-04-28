using UnityEngine;

public abstract class BaseClassDataPanel<T> : AbstractClassDataPanel where T : BaseClassData
{
    public override BaseClassData GetClassData => GetClassDataInner();

    protected abstract T GetClassDataInner();
}
