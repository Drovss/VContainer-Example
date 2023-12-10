using Core;
using Players.BulletScripts;
using UnityEngine;
using VContainer;

namespace Players
{
    public class Player : MonoBehaviour
    {
        //private IBullet _bullet = new Bullet(7);
        [Inject] private IBullet _bullet;
        
        [Inject] private ClassA a;
        
        
        [Inject] private IBullet Bullet { get; set; }

        private Gun _gun;

        [Inject]
        private void Construct(IBullet bullet)
        {
            _bullet = bullet;
        }

        private void Start()
        {
            
            _gun = new Gun(a.Bullet2);
            
            Fire(_gun);
        }

        private void Fire(Gun gun)
        {
            gun.Shoot();
            // ...
        }
    }
}