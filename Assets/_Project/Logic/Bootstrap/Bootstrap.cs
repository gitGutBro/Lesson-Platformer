using UnityEngine;
using _Project.Logic.Character.Characters;

namespace _Project.Logic.Bootstrap
{
    internal class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Enemy _enemyPrefab;
        
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Transform _enemySpawnPoint;

        private void Awake()
        {
            Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            Instantiate(_enemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
        }
    }
}