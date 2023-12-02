using Player.BulletScripts;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class Installer : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IBullet, BulletSupper>(Lifetime.Singleton)
                .WithParameter(5);
        }
    }
}