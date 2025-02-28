using Demo.DotnetCore.Strategy.Utilities;

namespace Demo.DotnetCore.Strategy.Strategies.Implementations;

/// <summary>
/// 戰士的攻擊策略
/// </summary>
public class WarriorAttackStrategy : IAttackStrategy
{
    private readonly IDamageCalculator _damageCalculator;

    /// <summary>
    /// 建構式
    /// </summary>
    public WarriorAttackStrategy(IDamageCalculator damageCalculator)
    {
        // 從建構式要求提供 IDamageCalculator 主要是為了示範和 .Net Core 的 DI 框架互動並取得實體的部份
        _damageCalculator = damageCalculator;
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    /// <returns>攻擊結果的描述字串</returns>
    public string Attack()
    {
        // 可能還有一堆有的沒的處理過程，磨刀之類的
        var damage = _damageCalculator.RollDamage(15, 30);
        return $"用大劍槌人，造成 {damage} 點傷害！";
    }
}