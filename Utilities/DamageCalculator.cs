namespace Demo.DotnetCore.Strategy.Utilities;

/// <summary>
/// 傷害產生器
/// </summary>
public interface IDamageCalculator
{
    /// <summary>
    /// 擲骰產生傷害
    /// </summary>
    /// <param name="minDamage">最小傷害值</param>
    /// <param name="maxDamage">最大傷害值</param>
    /// <returns>隨機傷害值</returns>
    int RollDamage(int minDamage, int maxDamage);
}

/// <summary>
/// 傷害產生器
/// </summary>
public class DamageCalculator : IDamageCalculator
{
    /// <summary>
    /// 擲骰產生傷害
    /// </summary>
    /// <param name="minDamage">最小傷害值</param>
    /// <param name="maxDamage">最大傷害值</param>
    /// <returns>隨機傷害值</returns>
    public int RollDamage(int minDamage, int maxDamage)
    {
        var seed = Guid.NewGuid().GetHashCode(); 
        var random = new Random(seed);
        return random.Next(minDamage, maxDamage + 1);
    }
}