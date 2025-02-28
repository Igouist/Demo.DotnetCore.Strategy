using Demo.DotnetCore.Strategy.Enums;

namespace Demo.DotnetCore.Strategy.Strategies;

/// <summary>
/// 攻擊策略工廠
/// </summary>
/// <remarks>
/// 備註：為了把根據職業選擇策略的部份封裝起來，因此才墊這層策略工廠，用來解耦合跟重複使用
/// 基本上就是用策略提供多條路線，然後工廠來把選路線的地方遮起來
/// 如果應用場景固定，也是可以先不抽這層出來，直接隔一個 Function 來處理這個選擇就好
/// </remarks>
public interface IAttackStrategyFactory
{
    /// <summary>
    /// 根據角色職業返回相應的攻擊策略實例
    /// </summary>
    /// <param name="occupation">角色職業，例如 "Warrior", "Mage", "Archer"</param>
    /// <returns>對應的攻擊策略</returns>
    IAttackStrategy GetStrategy(Occupation occupation);
}

/// <summary>
/// 攻擊策略工廠
/// </summary>
public class AttackStrategyFactory : IAttackStrategyFactory
{
    private readonly IAttackStrategy _warriorStrategy;
    private readonly IAttackStrategy _archerStrategy;
    private readonly IAttackStrategy _mageStrategy;

    /// <summary>
    /// 攻擊策略工廠
    /// </summary>
    public AttackStrategyFactory(
        [FromKeyedServices(Occupation.Warrior)] IAttackStrategy warriorStrategy, 
        [FromKeyedServices(Occupation.Archer)] IAttackStrategy archerStrategy, 
        [FromKeyedServices(Occupation.Mage)] IAttackStrategy mageStrategy)
    {
        _warriorStrategy = warriorStrategy;
        _archerStrategy = archerStrategy;
        _mageStrategy = mageStrategy;
    }

    /// <summary>
    /// 根據角色職業返回相應的攻擊策略實例
    /// </summary>
    /// <param name="occupation">角色職業，例如 "Warrior", "Mage", "Archer"</param>
    /// <returns>對應的 IAttackStrategy 實例</returns>
    public IAttackStrategy GetStrategy(Occupation occupation)
    {
        // 因為主要是 .Net 8 的範例，所以優先示範註冊 Keyed DI，注入後再根據目標對象再篩選的作法
        // 這樣的好處是不用自己處理依賴關係，靠依賴框架就可以解決一堆問題，反正策略裡面要的依賴也丟給 DI 框架自己解就好
        return occupation switch
        {
            Occupation.Warrior => _warriorStrategy,
            Occupation.Archer => _archerStrategy,
            Occupation.Mage => _mageStrategy,
            _ => throw new ArgumentOutOfRangeException($"不支援的職業：{occupation}")
        };

        // 如果不是支援 Keyed 的做法，通常會在各個策略加上一個標示用的欄位，例如在 WarriorAttackStrategy 加上：
        // public Occupation Occupation => Occupation.Warrior
        
        // 並且把上面的建構式改成整串丟進來：
        // private readonly IEnumerable<IAttackStrategy> _strategies;
        // public AttackStrategyFactory(IEnumerable<IAttackStrategy> strategies)
        
        // 然後就可以在這邊直接使用 FirstOrDefault 來取得對應的策略：
        // var strategy = _strategies.FirstOrDefault(s => s.Occupation == occupation);

        // 最後，如果不從 DI 框架取得，常見的範例可能會長這樣：
        // 這個範例會要求在這個工廠裡準備所有策略會用到的依賴對象（主要還是為了把選擇的邏輯封裝在這）
        // return occupation switch
        // {
        //     Occupation.Warrior => new WarriorAttackStrategy(),
        //     Occupation.Mage    => new MageAttackStrategy(),
        //     Occupation.Archer  => new ArcherAttackStrategy(),
        //     _ => throw new ArgumentException($"不支援的職業：{occupation}")
        // };
    }
}