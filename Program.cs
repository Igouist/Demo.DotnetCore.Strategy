using System.Reflection;
using Demo.DotnetCore.Strategy.Enums;
using Demo.DotnetCore.Strategy.Strategies;
using Demo.DotnetCore.Strategy.Strategies.Implementations;
using Demo.DotnetCore.Strategy.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDamageCalculator, DamageCalculator>();
builder.Services.AddSingleton<IArrowRepository, ArrowRepository>();

// 有支援 Keyed 具名註冊的版本才可以這樣做，否則要嘗試改成使用 AddTransient 並需要調整策略工廠
builder.Services.AddKeyedTransient<IAttackStrategy, WarriorAttackStrategy>(Occupation.Warrior);
builder.Services.AddKeyedTransient<IAttackStrategy, ArcherAttackStrategy>(Occupation.Archer);
builder.Services.AddKeyedTransient<IAttackStrategy, MageAttackStrategy>(Occupation.Mage);

builder.Services.AddTransient<IAttackStrategyFactory, AttackStrategyFactory>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();