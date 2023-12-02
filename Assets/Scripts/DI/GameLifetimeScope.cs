using Player.BulletScripts;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // builder.Register<Bullet>(Lifetime.Singleton)
        //     .As<IBullet>()
        //     .WithParameter(5);
        
        builder.Register<IBullet, Bullet>(Lifetime.Singleton)
            .WithParameter(5);
    }
}
