namespace Demo.DotnetCore.Strategy.Strategies;

/// <summary>
/// 攻擊策略
/// </summary>
public interface IAttackStrategy
{
    /// <summary>
    /// 執行攻擊動作
    /// </summary>
    /// <returns>攻擊結果的描述字串</returns>
    string Attack();
}