using System.Collections.Immutable;
using Demo.DotnetCore.Strategy.Utilities;

namespace Demo.DotnetCore.Strategy.Strategies.Implementations;

public class ArcherAttackStrategy : IAttackStrategy
{
    private readonly IDamageCalculator _damageCalculator;
    private readonly IArrowRepository _arrowRepository;

    /// <summary>
    /// 建構式
    /// </summary>
    public ArcherAttackStrategy(
        IDamageCalculator damageCalculator, 
        IArrowRepository arrowRepository)
    {
        // 弓箭手的建構式跟人家不一樣，是因為：我寫到這邊覺得應該加一點依賴對象不同的例子，才能展現策略跟 DI 框架配合的好用
        _damageCalculator = damageCalculator;
        _arrowRepository = arrowRepository;
    }
    
    /// <summary>
    /// 攻擊
    /// </summary>
    /// <returns>攻擊結果的描述字串</returns>
    public string Attack()
    {
        var isArrowConsumed = _arrowRepository.ConsumeArrow();
        if (isArrowConsumed is false)
        {
            return "沒有足夠的箭矢，無法進行攻擊！";
        }
        
        var damage = _damageCalculator.RollDamage(11, 19);
        return $"射出了一箭，造成 {damage} 點傷害！";
    }
}