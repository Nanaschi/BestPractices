using System;

public class ConfigProvider
{
    public event Action OnConfigChanged;
    private Configuration _configuration;

    public PlayerModel GetPlayerConfig => _configuration.PlayerData;
    public EnemyModel GetEnemyConfig => _configuration.EnemyModel;


    public void UpdateConfiguration(Configuration configuration)
    {
        _configuration = configuration;
        OnConfigChanged?.Invoke();
    }
}

public class EnemyModel
{
}

public class PlayerModel
{
    public float CurrentAmountOfHealth { get; set; }
    public float CurrentLevel { get; set; }
    public float AmountOfMoney { get; set; }
    public float BaseDamage { get; set; }
    public float WeaponDamage { get; set; }
    public float BaseMoveSpeed { get; set; }
}

public class Configuration
{
    public PlayerModel PlayerData { get; set; }
    public EnemyModel EnemyModel { get; set; }
}