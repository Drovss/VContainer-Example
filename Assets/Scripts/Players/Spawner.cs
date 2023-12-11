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

        [Inject] private IObjectResolver _resolver;
        
        private void Start()
        {
            _resolver.Instantiate(
                _playerPrefab,
                _spawnPoint.position,
                Quaternion.identity,
                null);
            
            // Instantiate(
            //     _playerPrefab,
            //     _spawnPoint.position,
            //     Quaternion.identity,
            //     null);

            // var bullet = _resolver.Resolve<IBullet>();
            //
            // _resolver.Inject(bullet);
            //
            // _resolver.InjectGameObject(_playerPrefab);
        }
    }
}