namespace Players.BulletScripts
{
    public class Bullet : IBullet, ISpeed
    {
        private readonly int _damage;

        public Bullet(int damage)
        {
            _damage = damage;
        }

        public int CalculateDamage()
        {
            return _damage;
        }
    }

    public interface ISpeed
    {
    }
}