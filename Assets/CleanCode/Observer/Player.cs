namespace CleanCode.Observer
{
    public class Player
    {
        private ConfigProvider _configProvider;

        private float _hitPoints, _damage, _baseMoveSpeed, _speedModifier;

        private IWeapon _weapon;


        void Initialize(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
            _configProvider.OnConfigChanged += UpdateConfiguration;
        }

        private void UpdateConfiguration()
        {
            var data = _configProvider.GetPlayerConfig;
            _hitPoints = data.CurrentAmountOfHealth;
            _damage = data.BaseDamage + data.WeaponDamage;
            _baseMoveSpeed = data.BaseMoveSpeed;
        }
    }

    internal interface IWeapon
    {
    }
}