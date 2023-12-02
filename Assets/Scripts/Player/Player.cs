using Player.BulletScripts;
using UnityEngine;
using VContainer;

namespace Player
{
    public class Player : MonoBehaviour
    {
        //private IBullet _bullet = new Bullet(7);
        [Inject] private IBullet _bullet;
        
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