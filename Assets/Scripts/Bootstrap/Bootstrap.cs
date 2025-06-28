using Character.Characters;
using UnityEngine;

namespace Bootstrap
{
    internal class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Enemy _enemyPrefab;
    
        [SerializeField] private GameObject _playerSpawnPoint;
        [SerializeField] private GameObject _enemySpawnPoint;

        private void Start()
        {
            Instantiate(_playerPrefab, _playerSpawnPoint.transform.position, Quaternion.identity);
            Instantiate(_enemyPrefab, _enemySpawnPoint.transform.position, Quaternion.identity);
        }
    }
}