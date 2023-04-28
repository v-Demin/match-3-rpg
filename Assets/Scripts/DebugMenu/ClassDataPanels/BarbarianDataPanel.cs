public class BarbarianDataPanel : BaseClassDataPanel<BarbarianData>
{
    protected override BarbarianData GetClassDataInner()
    {
        return new BarbarianData();
    }
}
