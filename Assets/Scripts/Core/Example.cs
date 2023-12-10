using Players.BulletScripts;

namespace Core
{
    public class Example
    {
        private readonly IBullet _bullet;

        public Example(IBullet bullet)
        {
            _bullet = bullet;
        }
    }
}