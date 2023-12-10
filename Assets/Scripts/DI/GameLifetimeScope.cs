using Core;
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
        builder.Register<ClassA>(Lifetime.Scoped);
    }

    private void RegisterGameWorld(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<GameWorld>();
    }

    private void RegisterGameWorlds(IContainerBuilder builder)
    {
        builder.UseEntryPoints(pointsBuilder =>
        {
            pointsBuilder.Add<GameWorld>();
            pointsBuilder.Add<GameWorld2>();
        });
    }

    private void RegisterBullet(IContainerBuilder builder)
    {
        builder.Register<Bullet>(Lifetime.Scoped).WithParameter(5);
        builder.Register<Bullet>(Lifetime.Singleton).WithParameter(5);
        builder.Register<Bullet>(Lifetime.Transient).WithParameter(5);
    }

    private void RegisterIBullet(IContainerBuilder builder)
    {
        builder.Register<IBullet, Bullet>(Lifetime.Singleton)
            .WithParameter(7);
        
        // builder.Register<Bullet>(Lifetime.Singleton)
        //     .As<IBullet>()
        //     .WithParameter(6);
    }
    
    private void RegisterManyInterfaces(IContainerBuilder builder)
    {
        builder.Register<GameWorld>(Lifetime.Singleton)
            .As<IStartable, ITickable>(); 
    }
    
    private void RegisterManyInterfacesAuto(IContainerBuilder builder)
    {
        builder.Register<GameWorld>(Lifetime.Singleton)
            .AsImplementedInterfaces();
    }
    
    private void RegisterManyInterfacesAutoAndSelf(IContainerBuilder builder)
    {
        builder.Register<GameWorld>(Lifetime.Singleton)
            .AsImplementedInterfaces()
            .AsSelf();
    }
    
    private void RegisterInstance(IContainerBuilder builder)
    {
        var bullet = new Bullet(9);

        builder.RegisterInstance(bullet);
    }
    
    private void RegisterInstanceAsInterface(IContainerBuilder builder)
    {
        var bullet = new Bullet(9);

        builder.RegisterInstance<IBullet>(bullet);
        
        builder.RegisterInstance(bullet)
            .As<IBullet>();

        builder.RegisterInstance(bullet)
            .AsImplementedInterfaces();
    }
    
    private void RegisterDelegate(IContainerBuilder builder)
    {
        builder.Register<IBullet>(_ =>
        {
            var bullet = new Bullet(9);
            return bullet;
        }, 
            Lifetime.Scoped);
    }
    
    private void RegisterDelegateWithResolve(IContainerBuilder builder)
    {
        builder.Register<IBullet>(container =>
        {
            var bullet = container.Resolve<Bullet>();
            return bullet;
        }, 
            Lifetime.Scoped);
    }

    [SerializeField] private Player _prefab;
    
    private void RegisterDelegateWithInstantiate(IContainerBuilder builder)
    {
        builder.Register(container =>
            {
                return container.Instantiate(_prefab);
            }, 
            Lifetime.Scoped);
    }
    
    [SerializeField] private Player _player;
    
    private void RegisterComponent(IContainerBuilder builder)
    {
        builder.RegisterComponent(_player);
    }
    
    private void RegisterComponentFromHierarchy(IContainerBuilder builder)
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
    
    private void RegisterComponentAsNewAndDDOL(IContainerBuilder builder)
    {
        builder.RegisterComponentOnNewGameObject<Player>(Lifetime.Scoped, "NewPlayer")
            .DontDestroyOnLoad();
    }
}
