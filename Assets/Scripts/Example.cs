using Players.BulletScripts;
using VContainer;

namespace DefaultNamespace
{
    public class Example
    {
        private readonly IBullet _bullet;
        
        [Inject] private readonly IBullet _bullet2;
        
        [Inject] private  IBullet Bullet3 { get; set; }

        public Example(IBullet bullet)
        {
            _bullet = bullet;
        }

        [Inject]
        public void SomeMethod(IBullet bullet)
        {
            
        }
    }
}