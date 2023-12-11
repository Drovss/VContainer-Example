using DefaultNamespace.EntryPoints;
using Players;
using Players.BulletScripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterIBullet(builder);
    }

    private void RegisterEntryPoints(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<GameWorld>();

        builder.UseEntryPoints(points =>
        {
            points.Add<GameWorld>();
            points.Add<GameWorld>();
        });
    }

    private void RegisterBullet(IContainerBuilder builder)
    {
        builder.Register<Bullet>(Lifetime.Scoped).WithParameter(5);
        builder.Register<Bullet>(Lifetime.Transient).WithParameter(5);
        builder.Register<Bullet>(Lifetime.Singleton).WithParameter(5);
    }
    
    private void RegisterIBullet(IContainerBuilder builder)
    {
        builder.Register<IBullet, Bullet>(Lifetime.Scoped)
            .WithParameter(9);
        
        // builder.Register<Bullet>(Lifetime.Scoped)
        //     .WithParameter(5)
        //     .As<IBullet>();
        //
        // builder.Register<Bullet>(Lifetime.Scoped)
        //     .WithParameter(5)
        //     .As<IBullet, ISpeed>();
        //
    }
    
    private void RegisterManyInterfaces(IContainerBuilder builder)
    {
        builder.Register<Bullet>(Lifetime.Scoped)
            .WithParameter(5)
            .AsImplementedInterfaces();

        builder.Register<Bullet>(Lifetime.Scoped)
            .WithParameter(5)
            .AsImplementedInterfaces()
            .AsSelf();

    }

    private void RegisterInstance(IContainerBuilder builder)
    {
        var bullet = new Bullet(7);

        builder.RegisterInstance(bullet);
    }
    
    private void RegisterInstanceAsInterface(IContainerBuilder builder)
    {
        var bullet = new Bullet(7);

        builder.RegisterInstance<IBullet>(bullet);

        builder.RegisterInstance(bullet)
            .AsImplementedInterfaces();

        builder.RegisterInstance(bullet)
            .AsImplementedInterfaces()
            .AsSelf();

        builder.RegisterInstance(bullet)
            .As<IBullet>();
    }

    private void RegisterDelegate(IContainerBuilder builder)
    {
        builder.Register<IBullet>(container =>
        {
            var bullet = new Bullet(7);
            return bullet;
        }, Lifetime.Scoped);
    }
    
    private void RegisterDelegateWithResolve(IContainerBuilder builder)
    {
        builder.Register<IBullet>(container =>
        {
            var bullet = container.Resolve<Bullet>();
            return bullet;
        }, Lifetime.Scoped);
    }

    [SerializeField] private Player _player;
    
    private void RegisterDelegateWithInstance(IContainerBuilder builder)
    {
        builder.Register(container =>
        {
            return container.Instantiate(_player);
        }, Lifetime.Singleton);
    }
    
    private void RegisterComponent(IContainerBuilder builder)
    {
        builder.RegisterComponent(_player);
    }
    
    private void RegisterComponentInHierarchy(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<Player>();
    }
    
    private void RegisterComponentAsNew(IContainerBuilder builder)
    {
        builder.RegisterComponentOnNewGameObject<Player>(Lifetime.Scoped, "NewPlayer");
    }
    
    [SerializeField] private Transform _parent;
    private void RegisterComponentAsNewWithParent(IContainerBuilder builder)
    {
        builder.RegisterComponentOnNewGameObject<Player>(Lifetime.Scoped, "NewPlayer")
            .UnderTransform(_parent);
    }
    
    private void RegisterComponentAsNewWithParentAsDDOL(IContainerBuilder builder)
    {
        builder.RegisterComponentOnNewGameObject<Player>(Lifetime.Scoped, "NewPlayer")
            .UnderTransform(_parent)
            .DontDestroyOnLoad();
    }
}
