using Players.BulletScripts;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        private IBullet _bullet = new Bullet(7);
        
        private IBullet Bullet { get; set; }

        private Gun _gun;

        private void Construct(IBullet bullet)
        {
            _bullet = bullet;
        }

        private void Start()
        {
            _gun = new Gun(_bullet);
            
            Fire(_gun);
        }

        private void Fire(Gun gun)
        {
            gun.Shoot();
            // ...
        }
    }
}