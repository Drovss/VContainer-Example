using UnityEngine;

namespace Players
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _spawnPoint;

        private void Start()
        {
            Instantiate(
                _playerPrefab,
                _spawnPoint.position,
                Quaternion.identity,
                null);
        }
    }
}