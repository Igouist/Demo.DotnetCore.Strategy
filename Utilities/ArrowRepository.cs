namespace Demo.DotnetCore.Strategy.Utilities;

public interface IArrowRepository
{
    /// <summary>
    /// 嘗試射掉(?)一支箭
    /// </summary>
    /// <returns>消耗箭矢是否成功</returns>
    bool ConsumeArrow();
}

public class ArrowRepository : IArrowRepository
{
    /// <summary>
    /// 嘗試射掉(?)一支箭
    /// </summary>
    /// <returns>消耗箭矢是否成功</returns>
    public bool ConsumeArrow() => true; // 這傢伙開掛
}