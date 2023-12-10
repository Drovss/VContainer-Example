using Players.BulletScripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Players
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _spawnPoint;

        [Inject] private IObjectResolver _container;
        
        private void Start()
        {
            _container.Instantiate(_playerPrefab,
                _spawnPoint.position,
                Quaternion.identity,
                null);
            
            // Instantiate(
            //     _playerPrefab,
            //     _spawnPoint.position,
            //     Quaternion.identity,
            //     null);

            // var bullet = _container.Resolve<IBullet>();
            //
            // _container.Inject(bullet);
            //
            // _container.InjectGameObject(_playerPrefab);
        }
    }
}