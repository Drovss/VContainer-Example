using Players.BulletScripts;
using VContainer;

namespace Core
{
    public class ClassA
    {
        public IBullet Bullet;
        
        [Inject]  public IBullet Bullet2;

        [Inject] public IBullet Bullet3 { get; set; }
        
        public IBullet Bullet4;

        public ClassA(IBullet bullet)
        {
            Bullet = bullet;
        }
        
        [Inject]
        public void Construct(IBullet bullet)
        {
            Bullet4 = bullet;
        }
    }

}