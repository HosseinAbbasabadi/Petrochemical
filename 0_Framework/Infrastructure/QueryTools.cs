namespace _0_Framework.Infrastructure;

public static class QueryTools
{
    public static string IndicateRemoveState(this bool isRemoved)
    {
        return isRemoved ? "حذف شده" : "فعال";
    }
}