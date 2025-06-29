using UnityEngine;

namespace _Project.Logic.Shared.Spawner
{
    public class Spawner : ISpawner
    {
        public void Spawn<T>(T spawnable, Transform spawnPoint) where T : MonoBehaviour, ISpawnable => 
            Object.Instantiate(spawnable, spawnPoint.position, Quaternion.identity);
    }
}