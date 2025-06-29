using UnityEngine;
using Zenject;
using _Project.Logic.Shared.Spawner;
using _Project.Logic.Character.Characters;

namespace _Project.Logic.Bootstrap
{
    internal class Bootstrap : MonoBehaviour
    {
        [Header("Characters prefabs")]
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Enemy _enemyPrefab;
        [Header("Characters spawn points")]
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Transform _enemySpawnPoint;
        
        private ISpawner _spawner;
        
        [Inject]
        private void Construct(ISpawner spawner) => 
            _spawner = spawner;

        private void Start()
        {
            _spawner.Spawn(_playerPrefab, _playerSpawnPoint);
            _spawner.Spawn(_enemyPrefab, _enemySpawnPoint);
        }
    }
}