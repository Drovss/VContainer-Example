using Players.BulletScripts;
using UnityEngine;

namespace Players
{
    public class Gun
    {
        private readonly IBullet _bullet;
        public Gun(IBullet bullet)
        {
            _bullet = bullet;
        }

        public void Shoot()
        {
            Debug.Log($"Bang: {_bullet.CalculateDamage()}");
        }
    }
}