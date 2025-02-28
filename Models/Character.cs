using Demo.DotnetCore.Strategy.Enums;

namespace Demo.DotnetCore.Strategy.Models;

/// <summary>
/// 角色
/// </summary>
public class Character
{
    public Character(
        int id,
        string name,
        Occupation occupation)
    {
        Id = id;
        Name = name;
        Occupation = occupation;
    }

    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; } = 0;
    
    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// 職業
    /// </summary>
    public Occupation Occupation { get; set; }
}