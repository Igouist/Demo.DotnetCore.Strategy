using Demo.DotnetCore.Strategy.Enums;
using Demo.DotnetCore.Strategy.Models;
using Demo.DotnetCore.Strategy.Strategies;
using Microsoft.AspNetCore.Mvc;

namespace Demo.DotnetCore.Strategy.Controllers;

/// <summary>
/// 角色動作
/// </summary>
[ApiController]
[Route("[controller]")]
public class CharacterController(
    ILogger<CharacterController> logger, 
    IAttackStrategyFactory strategyFactory) : ControllerBase
{
    /// <summary>
    /// 讓角色發動攻擊 (備註：目前角色 ID 只有 1~3 可用）
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]/{id:int}")]
    public string Attack(
        [FromRoute] int id)
    {
        var character = _characters.FirstOrDefault(x => x.Id == id);
        if (character is null)
        {
            return "查無此人";
        }
        
        var name = character.Name;
        var occupation = character.Occupation;
        
        var strategy = strategyFactory.GetStrategy(occupation);
        var attackResult = strategy.Attack();
        
        return $"{name} {attackResult}";
    }
    
    // 角色清單
    // 本來應該放在資料庫的，但我們租不起主機了，先頂著用
    private static List<Character> _characters =
    [
        new Character(id: 1, name: "小明", occupation: Occupation.Warrior),
        new Character(id: 2, name: "小華", occupation: Occupation.Archer),
        new Character(id: 3, name: "小美", occupation: Occupation.Mage)
    ];
}